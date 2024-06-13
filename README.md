Đề bài:
Cho một mảng số nguyên tạm gọi là nums và hai số nguyên tạm gọi là indexDiff và valueDiff (dữ liệu nhập vào thủ công)

Tìm cặp số (i, j) sao cho:

1. i != j,
2. abs(i - j) <= indexDiff (khoảng cách giữa hai chỉ số không vượt quá 'indexDiff')
3. abs(nums[i] - nums[j]) <= valueDiff (khoảng cách giữa hai giá trị không vượt quá 'valueDiff')
Trả về true nếu cặp đó tồn tại hoặc sai nếu không.

Cách tiếp cận:
Để tìm cặp chỉ số thoả mãn các điều kiện trên một cách hiệu quả, chúng ta có thể sử dụng kỹ thuật "Sliding Window" kết hợp với cấu trúc dữ liệu 'SortedSet' để duy trì các giá trị trong khoảng cách 'indexDiff'. 'SortedSet' giúp chúng ta có thể nhanh chóng kiểm tra xem có giá trị nào nằm trong khoảng 'valueDiff' hay không.

Giải thích mã:
1. Kiểm tra các điều kiện ban đầu: 
   
       if (indexDiff <= 0 || valueDiff < 0) {
           return false;
       }
    
    Nếu 'indexDiff' nhỏ hơn hoặc bằng 0 hoặc 'valueDiff' nhỏ hơn 0, chúng ta không thể tìm được cặp chỉ số thỏa mãn, trả về 'false'.

2. Khởi tạo 'SortedSet':
    
       SortedSet<long> set = new SortedSet<long>();
     
    'SortedSet' được dùng để duy trì các giá trị đã thấy trong khoảng cách 'indexDiff'.

3. Duyệt qua từng phần tử trong mảng:
    
       for (int i = 0; i < nums.Length; i++) {
           // Tìm vị trí để chèn giá trị hiện tại (sử dụng long để tránh tràn số nguyên)
           if (set.GetViewBetween((long)nums[i] - valueDiff, (long)nums[i] + valueDiff).Count > 0) {
               return true;
           }
   
           // Thêm giá trị hiện tại vào set
           set.Add((long)nums[i]);
   
           // Loại bỏ phần tử cũ nhất trong cửa sổ nếu cần
           if (i >= indexDiff) {
               set.Remove((long)nums[i - indexDiff]);
           }
       }
    
    - Kiểm tra giá trị: Sử dụng 'GetViewBetween' để lấy tất cả các giá trị trong 'SortedSet' nằm trong khoảng '[nums[i] - valueDiff, nums[i] + valueDiff]'. Nếu khoảng này không trống, nghĩa là có giá trị thỏa mãn điều kiện 'valueDiff'.
    - Thêm giá trị hiện tại: Thêm giá trị hiện tại vào 'SortedSet'.
    - Loại bỏ phần tử cũ nhất: Nếu chỉ số 'i' đã vượt qua 'indexDiff', loại bỏ phần tử cũ nhất ra khỏi 'SortedSet' để duy trì khoảng cách chỉ số.

Kết luận:
Với cách tiếp cận này, chúng ta có thể kiểm tra và tìm kiếm cặp chỉ số thỏa mãn điều kiện bài toán một cách hiệu quả. 'SortedSet' giúp ta duy trì các giá trị trong khoảng cách chỉ số và kiểm tra điều kiện khoảng cách giá trị một cách nhanh chóng.
