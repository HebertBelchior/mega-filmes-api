namespace MegaFilmes.Domain.Dtos;

public class PagedBaseRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
