//In the name of Allah

namespace Application.Utils;

public abstract class Routes
{
    public static string USER_VERIFY = "/user/verify";
    public static string USER_ADD = "/user/add";

    public static string PRODUCT_GET = "/product/get";
    public static string PRODUCT_GET_BY_NAME = "/product/get/{name}";
    public static string PRODUCT_ADD = "/product/add";
    public static string PRODUCT_UPDATE = "product/update";
    public static string PRODUCT_REMOVE = "product/remove";
    public static string TRANSACTION_GET = "/transaction/get";
    public static string TRANSACTION_ADD = "/transaction/add";
}//class