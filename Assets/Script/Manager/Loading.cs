using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class Loading : MonoBehaviour
{
    public Slider progressBar;  // Tham chiếu tới Slider dùng làm thanh tiến trình

    private void Awake()
    {
        //Time.timeScale = 0;
        // Gọi hàm để bắt đầu chạy thanh tiến trình
        StartCoroutine(FillProgressBarOverTime(2f));
    }
    private void Aw()
    {
          // Chạy thanh trong 2 giây
    }

    IEnumerator FillProgressBarOverTime(float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            // Tính toán tỷ lệ hoàn thành dựa trên thời gian đã trôi qua
            elapsedTime += Time.unscaledDeltaTime;
            float progress = Mathf.Clamp01(elapsedTime / duration);
            // Cập nhật giá trị của thanh tiến trình
            progressBar.value = progress;
            // (Tùy chọn) Cập nhật phần trăm hiển thị
          
            yield return null;  // Đợi frame tiếp theo
        }
        // Đảm bảo thanh tiến trình đầy đủ 100% khi hoàn thành
        progressBar.value = 1f;  
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
