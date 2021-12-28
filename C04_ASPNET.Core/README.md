# ASP.NET Core 쉽다!

- appsettings.json : 앱 설정 파일. 환경에 상관없이 공통적으로 사용되는 설정은 여기에 담깁니다.
- appsettings.{ENV}.json : 환경별 설정파일입니다. ASPNETCORE_ENVIRONMENT 환경변수의 지정된 값이 
  ENV에 매핑되어 우선 appsettings.json을 적용 후 추가 정의되어 있는 내용으로 덮어씌웁니다.
- Program.cs : top-level statements로 엔트리포인트 입니다.
  - `services.AddScoped<TInterface, TClass>` : IoC 컨테이너에 의존 클래스를 등록시킵니다.
    - AddScoped : 1 Request 에 1 Instance를 생성합니다.
      - Connection, Infra, HttpClient 등과 같이 해제가 필요한 비관리 리소스에 해당합니다.
      - Connection의 경우 1 Request에 재사용 되야하며 일반적인 Transaction Session도 어떻게 보면 여기에 해당할 수 있습니다.
    - AddTransient : 모든 Construct에 새로은 Instance를 주입합니다.
      - 자주 사용하지는 않지만, 클래스의 복잡도를 해소하기 위해 다른 분리 및 의존하거나 상태가 있는 무언가를 구현할 때 주로 쓰입니다. 
    - AddSingleton : 어플리케이션과 같은 라이프사이클을 가집니다.
      - 많이 생성할 필요가 전혀 없는 계산 로직, 헬퍼, 유틸성 클래스 등에 적합합니다.
      - 다만 Notifier, Event/Log Publisher 같이 어플리케이션 라이프사이클과 동일하게 살아 있어야하는 녀석이면 싱글톤으로 적합합니다.
      - Logger도 여기에 해당합니다.
- `Controllers/*Controller` : 컨트롤러 파일을 배치합니다.
- `Services/*Service` : 서비스 파일을 배치합니다. 별도의 컨벤션은 없으니 마음껏 하고 싶은대로 하면 좋습니다.

## Getting Start

```sh
dotnet run # 진짜 끝
dotnet watch run # 요견 변경사항이 있으면 알아서 릴로드 리스타트 해줌! 
```

이후 터미널 로그에 열리는 링크를 이용하여 `https://localhost:port/swagger` 로 접속하면 open api doc을 볼 수 있습니다.

이외 상세한 사항은 코드를 보시면 거의 대부분 아실 수 있으며, [공식문서](https://docs.microsoft.com/ko-kr/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0) 이라는 친절하고 방대한 양의 자료를 참조하시면 좋을 것 같습니다. 