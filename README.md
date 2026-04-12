# The Forsaken: Soul-Like Adventure

The Forsaken là một dự án game hành động nhập vai 2D (ARPG Platformer) mang phong cách dark fantasy. Trò chơi tập trung vào trải nghiệm chiến đấu có chiều sâu, hệ thống AI và không khí u tối của một thế giới đã bị lãng quên.

## Giới thiệu

Người chơi tỉnh dậy tại một nghĩa trang bị nguyền rủa, nơi chôn cất những linh hồn bị chối bỏ. Không ký ức, không danh tính, hành trình bắt đầu bằng việc đối mặt với những thực thể nguy hiểm để tìm lại bản ngã hoặc biến mất hoàn toàn.

## Tính năng chính

### Combat System
- Hệ thống combo nhiều giai đoạn cho nhân vật
- Đồng bộ animation và hitbox thông qua Animation Events
- Hỗ trợ animation cancelling và input buffer để tăng độ phản hồi

### Enemy AI
- Sử dụng NavMesh 2D cho pathfinding
- AI vận hành theo state machine: Idle, Patrol, Chase, Attack
- Đảm bảo hành vi mượt và ổn định trong gameplay

### Data Management
- Lưu trữ dữ liệu bằng JSON (player state, checkpoint, progression)
- Scene management giữ lại thông tin quan trọng giữa các khu vực
- Áp dụng mô hình Singleton cho quản lý dữ liệu

### UI và Cutscene
- UI động (HP, Mana, Boss Bar) phản hồi theo thời gian thực
- Hiệu ứng camera và screen shake khi nhận sát thương
- Cutscene được xây dựng bằng Unity Timeline

## Công nghệ sử dụng

- Unity (URP)
- C#
- Aseprite (Pixel Art, Animation)
- Figma (UI/UX)
- Git LFS

## Hướng dẫn chạy

1. Tải bản demo tại:
   https://drive.google.com/drive/folders/1ADzxwTgX2Ta_14YA9RvGLJdcv0l6dLcK
2. Giải nén file .zip
3. Chạy file Forsaken_MSL.exe

## Dev Log

- Tối ưu hệ thống combo và xử lý animation lặp
- Fix xung đột collider giữa player và enemy
- Hoàn thiện boss cho Chapter 1
