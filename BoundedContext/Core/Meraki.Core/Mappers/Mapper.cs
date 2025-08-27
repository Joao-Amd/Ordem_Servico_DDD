using System.Linq.Expressions;
using System.Reflection;

namespace Meraki.Core.Mappers
{
    public class Mapper
    {
        /// <summary>
        /// Gera uma expressão lambda que projeta um objeto do tipo TSource para TDest,
        /// mapeando propriedades por nome ou caminho especificado via atributo [MapFrom].
        /// Suporta propriedades aninhadas como "Endereco.Cidade.Nome".
        /// </summary>
        public Expression<Func<TSource, TDest>> Gerar<TSource, TDest>() where TDest : new()
        {
            // Obtém os tipos de origem e destino
            var sourceType = typeof(TSource);
            var destType = typeof(TDest);

            // Cria o parâmetro da expressão lambda (ex: "p => ...")
            var parameter = Expression.Parameter(sourceType, "p");

            // Lista de bindings que vão compor o MemberInit (inicialização das propriedades)
            var bindings = new List<MemberBinding>();

            // Itera sobre todas as propriedades públicas e graváveis do tipo de destino
            foreach (var destProp in destType.GetProperties().Where(p => p.CanWrite))
            {
                // Verifica se a propriedade tem o atributo [MapFrom] para indicar o caminho de origem
                var mapAttr = destProp.GetCustomAttribute<MapFromAttribute>();

                // Se tiver o atributo, usa o caminho especificado; senão, tenta usar o nome da propriedade
                var sourcePath = mapAttr?.Path ?? destProp.Name;

                // Inicializa a expressão atual com o parâmetro base (ex: "p")
                Expression current = parameter;
                Type currentType = sourceType;

                // Divide o caminho em partes (ex: "Endereco.Cidade.Nome") e navega pelas propriedades
                foreach (var part in sourcePath.Split('.'))
                {
                    var propInfo = currentType.GetProperty(part);
                    if (propInfo == null)
                    {
                        // Se não encontrar a propriedade em algum nível, ignora esse binding
                        current = null;
                        break;
                    }

                    // Atualiza a expressão para acessar a propriedade atual
                    current = Expression.Property(current, propInfo);
                    currentType = propInfo.PropertyType;
                }

                // Se não conseguiu construir a expressão completa, pula essa propriedade
                if (current == null) continue;

                // Verifica se o tipo da propriedade de destino é compatível com o tipo da expressão de origem
                if (!destProp.PropertyType.IsAssignableFrom(current.Type)) continue;

                // Cria o binding entre a propriedade de destino e a expressão de origem
                bindings.Add(Expression.Bind(destProp, current));
            }

            // Cria o corpo da expressão: new TDest { Prop1 = ..., Prop2 = ..., ... }
            var body = Expression.MemberInit(Expression.New(destType), bindings);

            // Retorna a expressão lambda completa: p => new TDest { ... }
            return Expression.Lambda<Func<TSource, TDest>>(body, parameter);
        }

    }
}
