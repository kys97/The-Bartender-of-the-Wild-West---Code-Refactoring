using UnityEngine;

public class Customer : MonoBehaviour
{
    Sprite Order;
    Sprite CustomerImage;
    int PlateNumber;

    string order_name;
    int customer_index;

    public void SetCustomerData(string order_name, int customer_index)
    {
        this.order_name = order_name;
        this.customer_index = customer_index;

        GameManager.Instance.GetResourceManager.DrinkList.TryGetValue(order_name, out Sprite value);
        Order = value;
        CustomerImage = GameManager.Instance.GetResourceManager.CustomerList[customer_index];
    }
}
