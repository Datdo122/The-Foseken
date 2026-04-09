# 🛡️ The Forsaken: Soul-Like Adventure

**The Forsaken** là một dự án game hành động nhập vai (ARPG) 2D Platformer mang đậm phong cách Dark Fantasy. Game được xây dựng trên nền tảng Unity, tập trung vào trải nghiệm chiến đấu thử thách, cốt truyện bí ẩn và không khí u tối của vùng đất chết.

---

## 📖 Giới thiệu cốt truyện
Bạn tỉnh dậy tại một nghĩa trang bị nguyền rủa — nơi chôn cất những linh hồn bị chối bỏ. Không ký ức, không danh tính, hành trình của bạn bắt đầu bằng việc đối mặt với **Gipsy** và những thực thể đáng sợ để tìm lại bản ngã hoặc tan biến vào hư không.

---

## ✨ Tính năng nổi bật (Core Features)

### ⚔️ Hệ thống Combat chuyên sâu
* **Combo-Step System:** Triển khai hệ thống tấn công 3 giai đoạn cho nhân vật **Jotem**. Mỗi đòn đánh được tinh chỉnh qua *Animation Events* để đồng bộ hóa hoàn hảo giữa hình ảnh và *Hitbox timing*.
* **Animation Cancelling & Buffer:** Tối ưu hóa "Game Feel", cho phép người chơi có phản hồi tức thì trong các tình huống né đòn hoặc tung combo liên hoàn.

### 🧠 Trí tuệ nhân tạo (Advanced AI)
* **Pathfinding 2D:** Kẻ địch sử dụng *NavMesh 2D* để truy đuổi người chơi thông minh, biết né tránh địa hình và tìm đường ngắn nhất.
* **State Machine Logic:** AI được quản lý bằng máy trạng thái (Idle, Patrol, Chase, Attack), đảm bảo hành vi của quái vật mượt mà và không bị xung đột script.

### 💾 Hệ thống Quản lý Dữ liệu
* **Persistence System:** Sử dụng định dạng **JSON** để lưu trữ trạng thái người chơi, vị trí Checkpoint và tiến trình nhiệm vụ, đảm bảo dữ liệu toàn vẹn sau khi thoát game.
* **Scene Management:** Chuyển cảnh chuyên nghiệp, giữ lại các thông số quan trọng (HP, vị trí) giữa các khu vực bằng mô hình *Singleton*.

### 🎬 Trải nghiệm Điện ảnh & UI
* **Dynamic UI:** Thanh HP/Mana và Boss Health Bar được thiết kế động, phản hồi thời gian thực với các hiệu ứng rung lắc (Screen Shake) khi nhận sát thương.
* **Timeline Cutscenes:** Các đoạn cắt cảnh mở đầu và hội thoại được tích hợp bằng *Unity Timeline*, tạo cảm giác liền mạch giữa gameplay và cốt truyện.

---

## 🛠️ Công nghệ sử dụng
* **Engine:** Unity 6 (URP - Universal Render Pipeline).
* **Ngôn ngữ:** C# (Object Oriented Programming).
* **Công cụ hỗ trợ:** * **Aseprite:** Sáng tạo Pixel Art & Animation.
    * **Figma:** Thiết kế giao diện (UI/UX).
    * **Git LFS:** Quản lý mã nguồn và tài nguyên dung lượng lớn.

---

## 🎮 Hướng dẫn trải nghiệm
1. Truy cập link [Demo Game tại đây](https://drive.google.com/drive/folders/1ADzxwTgX2Ta_14YA9RvGLJdcv0l6dLcK?usp=drive_link).
2. Tải và giải nén thư mục `.zip`.
3. Chạy file `Forseken_MSL.exe` để bắt đầu hành trình.

---

## 📝 Nhật ký phát triển (Dev Log)
*Hiện tại dự án đang tập trung xử lý các vấn đề sau:*
- [ ] Tối ưu hóa hệ thống Combo (Sửa lỗi lặp Animation khi click nhanh).
- [ ] Fix lỗi xung đột Collider giữa Player và Enemy.
- [ ] Hoàn thiện hệ thống Boss Chapter 1.
