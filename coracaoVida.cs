using UnityEngine;
using UnityEngine.UI;
public class coracao : MonoBehaviour
{
    public Image img;

    public  void Morte()
    {
        img.fillAmount -= 0.50f;
    }

    // vida
    
}
 