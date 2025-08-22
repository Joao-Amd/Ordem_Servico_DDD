namespace Meraki.Core.Patterns.Repositorys.ViewModels
{
    public class PaginationResult<TViewModel>
    {

        public int Total { get; set; }
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public IEnumerable<TViewModel> Content { get; set; } = new List<TViewModel>();
    }
}
