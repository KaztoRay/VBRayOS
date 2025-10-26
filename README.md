# VBRayOS

VBRayOS는 Visual Basic .NET과 Windows Forms를 사용하여 제작된 가상 운영체제 시뮬레이터입니다.

## 기능

- **부팅 화면**: 전체화면으로 실행되는 부팅 애니메이션
- **로그인 시스템**: 사용자명과 패스워드를 통한 인증
- **데스크톱 환경**: Windows 스타일의 데스크톱 인터페이스
- **작업 표시줄**: 시작 버튼과 시계가 포함된 하단 작업 표시줄
- **데스크톱 아이콘**: 내 컴퓨터, 인터넷, 휴지통 등의 기본 아이콘
- **파일 관리자**: 내 컴퓨터 아이콘 클릭 시 실행되는 파일 탐색기
- **브라우저 연동**: 인터넷 아이콘 클릭 시 시스템 기본 브라우저 실행
- **시스템 트레이**: 시스템 트레이 통합 및 최소화 기능
- **키보드 네비게이션**: 키보드를 통한 전체 인터페이스 탐색
- **창 상태 저장**: 창 위치와 크기 자동 저장 및 복원
- **스플래시 화면**: 향상된 시작 화면과 로딩 애니메이션

## 시스템 요구사항

- Windows OS
- .NET Framework 4.7.2 이상
- Visual Studio 2019 이상 (개발 환경)

## 실행 방법

1. Visual Studio에서 `VBRayOS.sln` 파일을 엽니다
2. 프로젝트를 빌드합니다 (F6)
3. 실행합니다 (F5)

## 프로젝트 구조

```
VBRayOS/
├── VBRayOS.sln           # Visual Studio 솔루션 파일
└── VBRayOS/              # 메인 프로젝트 폴더
    ├── Program.vb        # 애플리케이션 진입점
    ├── BootForm.vb       # 부팅 화면 폼
    ├── LoginForm.vb      # 로그인 화면 폼
    ├── DesktopForm.vb    # 데스크톱 환경 폼
    ├── FileManagerForm.vb # 파일 관리자 폼
    ├── VBRayOS.vbproj    # 프로젝트 파일
    ├── version_history.txt # 개발 히스토리
    └── My Project/       # 프로젝트 설정 파일들
        ├── AssemblyInfo.vb
        ├── Resources.resx
        └── Resources.Designer.vb
```

## 개발 정보

- 언어: Visual Basic .NET
- UI 프레임워크: Windows Forms
- 타겟 프레임워크: .NET Framework 4.7.2
- 개발 기간: 2013년 12월 ~ 2019년 12월
- 총 커밋 수: 4,400+ (지속적인 개발 및 개선)

## 버전 히스토리

프로젝트의 상세한 개발 히스토리는 `VBRayOS/version_history.txt` 파일에서 확인할 수 있습니다.

## 라이선스

이 프로젝트는 MIT 라이선스 하에 배포됩니다.

