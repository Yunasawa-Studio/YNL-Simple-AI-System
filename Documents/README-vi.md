<div align="center"><h1><i> YのL - Simple AI System (Instuction - VI) </i></h1></div>

<details>
<summary><h2><div id="part1"> ★ Cách sử dụng AI Behaviour Editor </div></h2></summary>
<ul>
  <li> Tạo <b> AI Behaviour </b> trong cửa sổ Project như sau và đặt tên tùy thích. </li>
  <br>
  <div align="center"><img width="100%" src="https://github.com/Yunasawa-Studio/YNL-Simple-AI-System/assets/113672166/f1aad95a-29bf-4245-b428-b3f99e232bff"></div>
  <br>
  <img align="right" src="https://github.com/Yunasawa-Studio/YNL-Simple-AI-System/assets/113672166/b46b3b5c-2952-41e5-90a0-068c3f0f4815">
  Một khi đã tạo xong <b> AI Behaviour </b>, click đúp để mở cửa sổ Editor. Hoặc bạn có thể mở một cách thủ công bằng các nút trên Toolbar.
  <br>
  <br>
  <br>
  <br>
  <li> Sau khi mở cửa sổ Editor, mọi thứ trông có vẻ trống không. </li>
  <img width="100%" src="https://github.com/Yunasawa-Studio/YNL-Simple-AI-System/assets/113672166/0b915e90-7724-4fd3-954b-a2f7ba35831a">
  <br>
  <img align="right" width=300px src="https://github.com/Yunasawa-Studio/YNL-Simple-AI-System/assets/113672166/7e6f1485-7647-439a-a1a4-9af76e0965af">
  <li> Click vào nút <code>Add State</code> và một khung state mới sẽ xuất hiện. Bạn có thể đặt tên cho state bằng cách nhấn nút hình "Cây bút" hoặc loại bỏ nó bằng nút X </li>
  <li> Hãy chắc chắn rằng tất cả các state đều có tên riêng biệt. </li>
  <br>
  <img align="right" width=300px src="https://github.com/Yunasawa-Studio/YNL-Simple-AI-System/assets/113672166/622c862f-4b97-435a-bfba-ede0ff086880">
  <li> Sau khi tạo tất cả các  bạn muốn, chọn một và trên màn hình chính, nhấn nút <code>Add</code> trên cửa sổ ACTION và cửa sổ TRANSITION. </li>
  <li> Bạn có thể nhấp vào khung để mở cửa sổ chọn, với khung Action, bạn có thể chọn các hành động mà bạn muốn và với khung Decision, bạn có thể chọn các quyết định cho các trạng thái tiếp theo. </li>
  <li> Cửa sổ trông như thế này: </li>
  <br>
  <br>
  <br>
  <br>
  <table>
  <tr>
    <th width="50%"><img src="https://github.com/Yunasawa-Studio/YNL-Simple-AI-System/assets/113672166/86ec9c3a-f5ea-449b-85c9-d1690d8da2eb"></th>
    <th width="50%"><img src="https://github.com/Yunasawa-Studio/YNL-Simple-AI-System/assets/113672166/dc0ca4eb-a4fa-439c-a9a9-cc31216f4743"></th>
  </tr>
  </table>
  <img align="right" width=300px src="https://github.com/Yunasawa-Studio/YNL-Simple-AI-System/assets/113672166/41e4cc63-249a-472a-a449-6b63edad1e6c">
  <li> Sau khi chỉnh sửa xong mọi thứ, hãy chọn AI Behaviour, chọn <code>Save Data</code> để lưu tất cả các thay đổi của bạn, nếu không, bạn sẽ hối hận vì đã không làm điều đó. </li>
</ul>

</details>

<details>
<summary><h2><div id="part1"> ★ Cách tạo script Action hoặc Decision tùy chỉnh </div></h2></summary>

<ul>
  <li> Đầu tiên, bạn cần chú ý một số điều quan trọng sau: </li>
  <ul>
  <li> Bất cứ khi nào bạn tạo Hành động hoặc Quyết định mới, hãy đảm bảo đặt nó trong không gian tên <code>YNL.SimpleAISystem</code>. </li>
  <li> Mọi Action được tạo phải có <code>AIAction</code> làm tiền tố và mọi Decision được tạo cũng phải có <code>AIDecision</code> làm tiền tố. </li>
 </ul>
 <br>
 <li> Bây giờ đến phần chính; sau khi làm theo các ghi chú ở trên và tạo Action hoặc Decision mới, bạn cần tạo 2 constructor, một không có tham số và một có <code>AIController</code> làm tham số duy nhất. </li>
 <br>
 <li> Bây giờ là phần của bạn, bên trong AIAction, có 5 phương thức mà bạn có thể override. </li>
 <ul>
    <li> <code>void Initialize(AIController controller)</code>: Tại đây bạn có thể khởi tạo bất cứ thứ gì bạn cần, ví dụ như GetComponent,... </li>
    <li> <code>void Convert(SerializableDictionary<string, string> properties)</code>: Tại đây bạn có thể chuyển keys và values thành các type mà bạn cần. Keys là tên của properties và values là giá trị của các properties đó. Bạn có thể xem code mẫu bên dưới để dễ hình dung hơn.</li>
    <li> <code>void DoAction()</code>: Thực thi hành động mà bạn muốn tại đây. </li>
    <li> <code>void OnEnterState()</code>: Hàm này sẽ được gọi mỗi khi vào một state mới. </li>
    <li> <code>void OnExitState()</code>: Hàm này sẽ được gọi mỗi khi thoát khỏi 1 state. </li>
  </ul>
  <br>
  <li> Đến với AIDecision, ở đây cũng có 5 phương thức mà bạn có thể override. </li>
  <ul>
    <li> <code>void Initialize(AIController controller)</code>: Tại đây bạn có thể khởi tạo bất cứ thứ gì bạn cần, ví dụ như GetComponent,... </li>
    <li> <code>void Convert(SerializableDictionary<string, string> properties)</code>: Tại đây bạn có thể chuyển keys và values thành các type mà bạn cần. Keys là tên của properties và values là giá trị của các properties đó. Bạn có thể xem code mẫu bên dưới để dễ hình dung hơn.</li>
    <li> <code>bool DoDecision()</code>: Ở đây bạn quyết định điều kiện nào để chuyển sang state khác bằng cách trả về một boolean. </li>
    <li> <code>void OnEnterState()</code>: Hàm này sẽ được gọi mỗi khi vào một state mới. </li>
    <li> <code>void OnExitState()</code>: Hàm này sẽ được gọi mỗi khi thoát khỏi 1 state. </li>
  </ul>
</ul>

<details>
<summary> AIActionSample.cs (Sample for custom AIAction script) </summary>

```csharp
using UnityEngine;
using YNL.Extensions.Methods;
using YNL.Utilities.Addons;

namespace YNL.SimpleAISystem
{
    public class AIActionSample : AIAction
    {
        public AIActionSample() : base(null) { }
        public AIActionSample(AIController controller) : base(controller) { }

        // Để thuộc tính mà bạn muốn ẩn thành private; Editor hiện tại chưa hỗ trợ
        // các thuộc tính tham chiếu, hãy tham chiếu chúng thông qua hàm Initialize()
        private Rigidbody _rigidbody;

        // Để thuộc tính mà bạn muốn hiện lên Editor thành public 
        public int Distance;
        public KeyCode KeyCode;

        public override void Initialize(AIController controller)
        {
            base.Initialize(controller);

            _rigidbody = controller.Root.GetComponent<Rigidbody>();
        }

        public override void Convert(SerializableDictionary<string, string> properties)
        {
            // Sử dụng các hàm chuyển đổi để biến string thành kiểu mà bạn cần
            Distance = int.Parse(properties["Distance"]);

            // Đối với enum bạn có thể dùng hàm MEnum.Parse<T>(string) như sau
            KeyCode = MEnum.Parse<KeyCode>(properties["KeyCode"]);
        }

        public override void DoAction()
        {
            // Thực thi hành động
        }

        public override void OnEnterState()
        {
            // Làm gì đó khi bắt đầu state
        }

        public override void OnExitState()
        {
            // Làm gì đó khi thoát khỏi state
        }
    }
}
```

</details>

<details>
<summary> AIDecisionSample.cs (Sample for custom AIAction script) </summary>

```csharp
using UnityEngine;
using YNL.Extensions.Methods;
using YNL.Utilities.Addons;

namespace YNL.SimpleAISystem
{
    public class AIDecisionSample : AIDecision
    {
        public AIDecisionSample() : base(null) { }
        public AIDecisionSample(AIController controller) : base(controller) { }

        // Để thuộc tính mà bạn muốn ẩn thành private; Editor hiện tại chưa hỗ trợ
        // các thuộc tính tham chiếu, hãy tham chiếu chúng thông qua hàm Initialize()
        private Rigidbody _rigidbody;

        // Để thuộc tính mà bạn muốn hiện lên Editor thành public
        public int Distance;
        public KeyCode KeyCode;

        public override void Initialize(AIController controller)
        {
            base.Initialize(controller);

            _rigidbody = controller.Root.GetComponent<Rigidbody>();
        }

        public override void Convert(SerializableDictionary<string, string> properties)
        {
            // Sử dụng các hàm chuyển đổi để biến string thành kiểu mà bạn cần
            Distance = int.Parse(properties["Distance"]);

            // Đối với enum bạn có thể dùng hàm MEnum.Parse<T>(string) như sau
            KeyCode = MEnum.Parse<KeyCode>(properties["KeyCode"]);
        }

        public override bool DoDecision()
        {
            // Quyết định quá trình chuyển đối của state
            return true;
        }

        public override void OnEnterState()
        {
            // Làm gì đó khi bắt đầu state
        }

        public override void OnExitState()
        {
            // Làm gì đó khi thoát khỏi state
        }
    }
}
```

</details>

<details>
<summary><h2><div id="part1"> ★ Cách thiết lập đối tượng AI của bạn </div></h2></summary>

<ul>
  <li> Bạn có thể mở Scene mẫu để hình dung rõ hơn về những gì bạn cần. Vào bên trong <code>Packages/YのL - Simple AI System/Sample/Sample Scene</code>; hiện tại bạn không thể mở scene vì bạn không có quyền mở read-only scene từ một package. Nhưng đừng lo lắng, tất cả những gì bạn cần làm chỉ là sao chép scene và dán nó vào nơi bạn muốn; sau đó bây giờ bạn có thể mở nó </li>
  <li> Hãy nhìn vào đối tượng <code>AI Root</code>, nó chứa thành phần <code>AI Root (Script)</code>, khi đó nó sẽ là thành phần bạn cần thêm vào đối tượng AI. Nếu nó có animations, hãy thêm cả <code>Animator</code> nữa. </li>
  <li> Nhìn vào đối tượng con <code>AI Controller</code>, đây là Controller của hệ thống AI. Thêm thành phần này và thả <code>AI Behaviour</code> mà bạn muốn sử dụng vào bên trong. (<code>AIController</code> phải nằm trong đối tượng con của <code>AIRoot</code>) </li>
 <li> Mọi thứ đã xong, nếu bạn chưa thực hiện Action để lấy được Target; hãy đảm bảo đặt một đối tượng vào trong trường <code>Target</code> nếu không nó sẽ báo lỗi. </li>
</ul>

</details>



</details>


