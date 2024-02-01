using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Unity : MonoBehaviour
{
    /************************************************************************
	 * 유니티 입력
	 * 
	 * 유니티에서 사용자의 명령을 감지할 수 있는 수단
	 * 사용자는 외부 장치를 이용하여 게임을 제어할 수 있음
	 * 유니티는 다양한 타입의 입력기기(키보드 및 마우스, 조이스틱, 터치스크린 등)를 지원
	 ************************************************************************/


    // <Device>
    // 특정한 장치를 기준으로 입력 감지
    // 특정한 장치의 입력을 감지하기 때문에 여러 플랫폼에 대응이 어려움
    // 위와 같은 이유로 현재는 자주 사용하는 방법이 아니다
    private void InputByDevice()
    {
        // 키보드의 입력감지
        if (Input.GetKey(KeyCode.Space))            // 누르고 있을 때
            Debug.Log("Space key is pressing");
        if (Input.GetKeyDown(KeyCode.Space))        // 눌렀을 때
            Debug.Log("Space key is down");
        if (Input.GetKeyUp(KeyCode.Space))          // 땠을 때
            Debug.Log("Space key is up");

        // 마우스의 입력감지
        if (Input.GetMouseButton(0))                // 누르고 있을 때
            Debug.Log("Mouse left button is pressing");
        if (Input.GetMouseButtonDown(0))            // 눌렀을 때
            Debug.Log("Mouse left button is down");
        if (Input.GetMouseButtonUp(0))              // 땠을 때
            Debug.Log("Mouse left button is up");
    }



    // <InputManager>
    // 여러 장치의 입력을 입력매니저에 이름과 입력을 정의
    // 입력매니저의 이름으로 정의한 입력의 변경사항을 확인
    // 유니티 에디터의 Edit -> Project Settings -> Input Manager 에서 관리

    // 단, 유니티 초창기의 방식이기 때문에 키보드, 마우스, 조이스틱에 대한 장치만을 고려함
    // 모바일이 없다!
    // 추가) VR Oculus Integraion Kit 같은 경우 입력매니저와 유사한 방식을 사용
    private void InputByInputManager()
    {
        // 축 입력
        // Horizontal(수평) : 키보드(a,d / ←, →), 조이스틱(왼쪽 아날로그스틱 좌우)
        float x = Input.GetAxis("Horizontal");
        // Vertical(수직) : 키보드(w,s / ↑, ↓), 조이스틱(왼쪽 아날로그스틱 상하)
        float y = Input.GetAxis("Vertical");

        // 버튼 입력
        // Fire1 : 키보드(Left Ctrl), 마우스(Left Button), 조이스틱(button0)으로 정의됨
        if (Input.GetButton("Fire1"))
            Debug.Log("Fire1 is pressing");
        if (Input.GetButtonDown("Fire1"))
            Debug.Log("Fire1 is down");
        if (Input.GetButtonUp("Fire1"))
            Debug.Log("Fire1 is up");
    }



    // <InputSystem>
    // Unity 2019.1 부터 지원하게 된 입력방식
    // 컴포넌트를 통해 입력의 변경사항을 확인
    // GamePad, JoyStick, Mouse, Keyboard, Pointer, Pen, TouchScreen, XR 기기 등을 지원
    private void InputByInputSystem()
    {
        // InputSystem은 이벤트 방식으로 구현됨
        // Update마다 입력변경사항을 확인하는 방식 대신 변경이 있을 경우 이벤트로 확인
        // 메시지를 통해 받는 방식과 이벤트 함수를 직접 연결하는 방식 등으로 구성
    }

    // Move 입력에 반응하는 OnMove 메시지 함수
    Vector3 moveDir;
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveDir.x = input.x;
        moveDir.z = input.y;
        Debug.Log("움직인다!");
    }
    public Rigidbody rigid;
    private void OnJump(InputValue value)
    {
        bool input = value.isPressed;
        Debug.Log("점프한다!");
        rigid.AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }
    private void Update()
    {
        //InputByDevice();
        //InputByInputManager();
        //InputByInputSystem();
        transform.position += moveDir * Time.deltaTime * 3f;
    }

}
