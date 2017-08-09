namespace CoreWebAngularApp.Services.Contracts
{
    public interface ITypeHelperService
    {
        bool TypeHasProperty<T>(string fields);
    }
}