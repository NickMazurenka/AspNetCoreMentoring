# IO.Swagger.Api.ProductsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Delete**](ProductsApi.md#delete) | **DELETE** /api/Products/{id} | 
[**Get**](ProductsApi.md#get) | **GET** /api/Products | 
[**Get_0**](ProductsApi.md#get_0) | **GET** /api/Products/{id} | 
[**Post**](ProductsApi.md#post) | **POST** /api/Products | 
[**Put**](ProductsApi.md#put) | **PUT** /api/Products/{id} | 


<a name="delete"></a>
# **Delete**
> void Delete (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteExample
    {
        public void main()
        {
            var apiInstance = new ProductsApi();
            var id = 56;  // int? | 

            try
            {
                apiInstance.Delete(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProductsApi.Delete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="get"></a>
# **Get**
> List<ProductGetDto> Get ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetExample
    {
        public void main()
        {
            var apiInstance = new ProductsApi();

            try
            {
                List&lt;ProductGetDto&gt; result = apiInstance.Get();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProductsApi.Get: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<ProductGetDto>**](ProductGetDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="get_0"></a>
# **Get_0**
> ProductGetDto Get_0 (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class Get_0Example
    {
        public void main()
        {
            var apiInstance = new ProductsApi();
            var id = 56;  // int? | 

            try
            {
                ProductGetDto result = apiInstance.Get_0(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProductsApi.Get_0: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

[**ProductGetDto**](ProductGetDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="post"></a>
# **Post**
> ProductGetDto Post (string productName = null, int? categoryId = null, string quantityPerUnit = null, double? unitPrice = null, int? unitsInStock = null, int? unitsOnOrder = null, int? reorderLevel = null, bool? discontinued = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PostExample
    {
        public void main()
        {
            var apiInstance = new ProductsApi();
            var productName = productName_example;  // string |  (optional) 
            var categoryId = 56;  // int? |  (optional) 
            var quantityPerUnit = quantityPerUnit_example;  // string |  (optional) 
            var unitPrice = 1.2;  // double? |  (optional) 
            var unitsInStock = 56;  // int? |  (optional) 
            var unitsOnOrder = 56;  // int? |  (optional) 
            var reorderLevel = 56;  // int? |  (optional) 
            var discontinued = true;  // bool? |  (optional) 

            try
            {
                ProductGetDto result = apiInstance.Post(productName, categoryId, quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProductsApi.Post: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **productName** | **string**|  | [optional] 
 **categoryId** | **int?**|  | [optional] 
 **quantityPerUnit** | **string**|  | [optional] 
 **unitPrice** | **double?**|  | [optional] 
 **unitsInStock** | **int?**|  | [optional] 
 **unitsOnOrder** | **int?**|  | [optional] 
 **reorderLevel** | **int?**|  | [optional] 
 **discontinued** | **bool?**|  | [optional] 

### Return type

[**ProductGetDto**](ProductGetDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="put"></a>
# **Put**
> ProductGetDto Put (int? id, string productName = null, int? categoryId = null, string quantityPerUnit = null, double? unitPrice = null, int? unitsInStock = null, int? unitsOnOrder = null, int? reorderLevel = null, bool? discontinued = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PutExample
    {
        public void main()
        {
            var apiInstance = new ProductsApi();
            var id = 56;  // int? | 
            var productName = productName_example;  // string |  (optional) 
            var categoryId = 56;  // int? |  (optional) 
            var quantityPerUnit = quantityPerUnit_example;  // string |  (optional) 
            var unitPrice = 1.2;  // double? |  (optional) 
            var unitsInStock = 56;  // int? |  (optional) 
            var unitsOnOrder = 56;  // int? |  (optional) 
            var reorderLevel = 56;  // int? |  (optional) 
            var discontinued = true;  // bool? |  (optional) 

            try
            {
                ProductGetDto result = apiInstance.Put(id, productName, categoryId, quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProductsApi.Put: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 
 **productName** | **string**|  | [optional] 
 **categoryId** | **int?**|  | [optional] 
 **quantityPerUnit** | **string**|  | [optional] 
 **unitPrice** | **double?**|  | [optional] 
 **unitsInStock** | **int?**|  | [optional] 
 **unitsOnOrder** | **int?**|  | [optional] 
 **reorderLevel** | **int?**|  | [optional] 
 **discontinued** | **bool?**|  | [optional] 

### Return type

[**ProductGetDto**](ProductGetDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

