using Recipes.Client.Core;
using Refit;

namespace Recipes.Mobile.Repositories;

public abstract class ApiGateway
{
    protected Task<Result<TType>>
        InvokeAndMap<TType>(
        Task<ApiResponse<TType>> call)
    =>  InvokeAndMap(call, e => e);


    protected async Task<Result<TResult>> 
        InvokeAndMap<TResult, TDtoResult>(
        Task<ApiResponse<TDtoResult>> call, 
        Func<TDtoResult, TResult> mapper)
    {
        try
        {
            var response = await call;

            if (response.IsSuccessStatusCode)
            {
                return Result<TResult>
                    .Success(mapper(response.Content));
            }
            else
            {
                return Result<TResult>
                    .Fail("FAILED_REQUEST", response.Error.StatusCode.ToString());
            }
        }
        catch (ApiException aex)
        {
            return Result<TResult>
                .Fail("ApiException", aex.StatusCode.ToString(), aex);
        }
        catch (Exception ex)
        {
            return Result<TResult>.Fail(ex);
        }
    }

}
