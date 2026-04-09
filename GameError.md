* (Player) Khi click quá nhanh, sau khi combostep reset và quay trở về 1 quá nhanh, animtion sẽ đủ điều kiện để attack combo1 mà k cần qua base attack, dẫn đến 2 attack combo1 cùng 1 lúc (chỉ 2 lần/nhiều click) -- chưa fix dc
* (Enemy) Chuyển đổi giữa tuần tra (platrollEnemyAI) và target (chaseAttackAI) không được, do đang dùng bật tắt component hàm update bị break và không chạy lại mặc dù đã dùng onenable -- chưa biết fix (logic đúng nhưng không hiểu sao không chạy lại update sau khi bật lại component scrip)
* (Enemy) Lỗi xung đột onTriggerEnter2d, 1 enemy có tới 2 OntriggerEnter2d dân đến nó bị lỗi target player và tính toán distance đến player (ontriger2d target đang chạy, thì hitattack kiểm tra thêm ontrigger2d và active false khi hết khung hình đan đến không thể tính toán distance) -- tạm thời sửa: tính dame bằng khoảng cách để nhận dame (nếu player k kịp ra khỏi khoảng cách gần thì nhận dame)
* tutorial không tắt nhân vật để nhìn chỉ dẫn -- fix sau

