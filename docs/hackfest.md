마케팅 전문 기업 [매드업](http://madup.com/)은 고객들의 문의사항이나 불만사항들을 수집하여 분석하고 있습니다. 이 데이터를 사용하여 고객지원 업무의 일부를 챗봇을 통해서 지원하는 프로젝트를 이번 Hackfest를 통해서 검증해 보기로 하였습니다. 이 챗봇의 이름은 KetBot이라고 붙였고 두가지 버전으로 구현을 했습니다. KetBot v1은 미리 만들어 놓은 질문과 답변을 3단계의 카테고리에 넣어놓고 고객이 카테고리를 선택해서 들어오면 답변을 얻을 수 있고, KetBot v2는 자연어 처리를 붙여 채팅 형식으로 구현했습니다. Microsoft Bot Framework를 사용하여 챗봇을 구현하고 Microsoft Azure의 Cosmos DB, Azure Search 등을 백엔드에서 사용하여 데이터를 처리했습니다. 특히 KetBot v2에서는 고객들과의 자연스러운 채팅을 구현하기 위해 Microsoft Cognitive Services의 자연어 처리 서비스인 LUIS(Language Understanding Intelligent Service)를 사용했습니다. 

Hackfest 멤버
- 김국진: Madup, CTO
- 송우석: Madup, CDO
- 이봉진: Madup, Software Engineer
- 이주민: Madup, Software Engineer
- 오일석: Microsoft, Technical Evangelist
- 류혜원: Microsoft, Audience Evangelism Manager

사용한 기술

Bot 
- Visual Studio 2017 / C# 
- [Bot Framework Template](http://aka.ms/bf-bc-vstemplate)
- [Bot Framework Emulator](https://docs.microsoft.com/en-us/bot-framework/debug-bots-emulator)

App 
- Eclipse 
- Java 
- Android ADT, GIT
- [Direct Line REST API 3.0](https://docs.botframework.com/en-us/restapi/directline3)

## 고객사 ## 

[매드업](http://madup.com/)은 2011년 설립된 마케팅 전문기업으로 [핀켓(FINKET)](https://play.google.com/store/apps/details?id=com.madup.pocket)이라는 Mobile Finance Service를 운영하고 있습니다. 핀켓 앱은 스마트폰의 잠금화면에 신뢰성 있는 금융 기사와 포인트 통합 그리고 편리한 멤버십 적립과 개인 금융 서비스를 제공하고 광고주에게는 금융 광고 플랫폼을 제공합니다. 한국 앱스토어의 라이프스타일 분야에서 다운로드 2위를 기록하였으며 Finance 분야에 여러번 featured 되었습니다.
특히 카드 적립포인트나 상품권과 같이 현금처럼 사용할 수 있는 포인트를 다루기 때문에 고객들의 문의사항이 많은 편입니다.

 
## 고객의 난제 ##

현재 핀켓 앱에서 고객문의를 처리하는 방식은, 고객이 "사용자 의견" 버튼을 누르면 제목과 내용을 입력할 수 있는 폼이 나오고 내용을 입력하고 전송하면 담당자가 전화, 이메일, 푸시알림 등을 이용하여 응답하는 방식입니다. 이런 프로세스는 보통 잘 작동되지만 업무시간이 지나면 응답을 할 수 없는 단점이 있습니다. 사실 별도 처리 프로세스가 필요없는 단순한 문의의 경우는 빠르게 응답 할 수 있음에도 불구하고 고객에게는 시간이 오래 걸리고 CS 담당자에게는 반복적인 작업이 됩니다. 특히 한명이 이미 여러가지 업무를 수행하고 있는 스타트업의 특성상 CS 업무는 모두에게 부담이 되는 업무가 되었고 가장 중요한 일임에도 불구하고 소홀이 다뤄지는 문제가 있습니다. 

따라서 챗봇을 통해서 단순한 문의에 대한 업무를 자동화하여 24시간 빠르게 대응하고 챗봇이 처리할 수 없는 업무에 대해서는 담당자에게 처리 요청이 가도록 프로세스를 개선할 수 있다면 고객과 직원이 모두 만족할 것입니다. 단순한 질문 외에도 서버스의 API를 점차 개선하여 포인트 조회, 사용내역 조회 등의 업무를 챗봇으로 이전하는 등 지속적인 개선이 가능할 것으로 예상됩니다. 
 
## Solution and steps ##

### KetBot v1 ###

#### CS 데이터의 분석 ####
그 동안 서비스를 운영하면서 쌓아놓은 약 2400건의 고객의 질문과 답변 중에서 가장 빈도가 높은 질문을 뽑아서 3단계 카테고리로 정의했습니다. 최종 질문과 그 질문에 적합한 답변 데이터도 준비를 해서 엑셀로 만들고 Azure SQL Database에 저장했습니다. 

고객이 "포인트 통합 > 포인트 통합오류 > 보안문자"를 선택하면 "보안문자 입력이 안되고 오류가 있습니다" 라는 질문이 선택되고 이 질문에 대한 준비된 답변을 고객에게 보여주는 방식입니다. 답변은 같은 내용이지만 3가지 버전으로 준비해서 조금이라도 사람의 느낌을 주려고 노력했습니다. 

![Ketbot v1 Basic Datam](images/v1-basic-data.png)

#### KetBot v1 아키텍쳐 ####

Ketbot은 기존 핀켓앱에 통합되어 배포가 될 예정이기 때문에 Microsoft Bot Framework가 지원하는 Skype, Facebook Messenger등의 채널을 사용하지 않고 Android 기반의 앱을 직접 개발하기로 결정했습니다. Bot Connector와 연결을 위해서 Direct Line이라는 채널을 사용했습니다. Direct Line은 REST 방식의 API로 인증을 하고 대화를 주고 받는 API를 제공 합니다. 

사용자는 Android앱을 통해서 메시지를 입력하여 Bot에 전달하거나 Bot이 전달 해준 메시지를 받습니다. 사용자가 입력한 메시지는 Direct Line REST API를 통해서 Bot Connector에 전달 되고 Bot Connector는 해당 대화에 메시지를 전달 합니다. Bot은 적절한 질문과 대답을 데이터베이스에서 조회해서 사용자에게 전달합니다. Bot은 Azure Web App 에 배포해서 운영하고 데이터 베이스는 Azure SQL Database를 사용합니다. 

![Ketbot v1 Basic Data](images/ketbot-v1-arch-diagram.png)

#### KetBot v1의 Dialog 흐름 ####

HackFest의 결과물인 소스코드는 오픈소스로 [Github](https://github.com/MadupPinket/ket-bot) 에 공개 되어 있습니다. Bot Builder SDK의 가장 핵심적인 코드는 바로 IDialog 인터페이스를 상속받은 Dialog 클래스들 입니다. FINKET Bot 에서는 5개의 Dialog를 체인으로 연결해서 대화의 흐름을 만들어 냈습니다. 

![KetBot v1 Dialogs](images/madup-bot-code-flow.jpg)

Microsoft Bot Framework의 기본 설계 철학 중 하나는 Stateless 입니다. 따라서 대화 중에 저장되어야 하는 상태 값들은 모두 Bot State Service에 저장해서 Bot 자체는 상태를 가지고 있지 않도록 해야만 합니다. 그러면 Bot을 호스팅하고 있는 웹앱을 여러 대로 늘리는 Scale Out을 해도 문제가 발생하지 않습니다. 


### KetBot v2 ###

### 기존 CS 데이터의 분석 ###

약 2000건의 CS 데이터에서 유효한 핵심어들을 추출하는 과정이 먼저 진행되었습니다. 가공하지 않은 CS 데이터를 사용해서 LUIS를 학습 시키기는 어렵기 때문에 학습을 위한 데이터가 먼저 추출되어야 합니다. 이를 위하여 각 문장이 가진 단어의 패턴과 유형을 다양한 자연어처리, 머신러닝 기법을 이용하여 찾아내며, 그 결과로 나온 핵심 단어들을 문장으로 재구성 했습니다. 재구성 된 문장의 정합성을 체크하는 backward, forward test를 거쳤습니다. 이 과정을 통과한 단어가 곧 LUIS에서 사용할 Entity 와 Feature이며 단어들이 모여 구성한 집합은 각각 하나의 Intent를 형성합니다. 분석에 R 을 사용하였고 최종 정리는 엑셀을 활용 했습니다. 

**핵심단어 클러스터링**

![Entity Clustering](images/entity-clustering.png)

**backward + forward test table**

![Entity Clustering](images/backward-forward-test-table.jpg)

**최종적으로 산출된 IEQA(Intent-Entity/Question-Answer) Matrix**

![Entity Clustering](images/ieqa-matrix.jpg)

#### LUIS 학습 ####

분석된 데이터를 기반으로 LUIS를 학습 시켰습니다. 총 43개의 Intent와 25개의 Entity가 정의 되었습니다. 기존 확보된 2000개의 고객데이터를 직접 사용해서 학습 시키기 위해 API를 통해서 2000개를 모두 요청하고 Suggested Utterances 에 들어온 데이터를 이용해서 하나씩 학습을 진행했습니다. 

LUIS Intent, Entity
![Entity Clustering](images/luis-entity.jpg)

![Entity Clustering](images/luis-intent.jpg)

#### KetBot v2 아키텍쳐 ####

KetBot v1에서 추가된 부분은 LUIS의 사용입니다. 사용자의 메시지는 LUIS로 요청되어 Intent를 받아오고 Entity를 통해서 검색어를 추출합니다. KetBot v2에서는 검색엔진을 사용했습니다. 데이터는 Azure Cosmos DB를 DocumentDB API로 만들어서 질문과 대답을 넣어서 인덱싱하여 준비하고 KetBot의 검색 요청에 응답합니다. 포인트 조회등의 Intent는 Finket API를 통해서 포인트를 조회해서 응답합니다. 

![KetBot v2 Architecture Diagram](images/ketbot-v2-diagram.jpg)

## Technical delivery ##




 
## Conclusion ##


## Additional resources ##

- [Ketbot v1 source code](https://github.com/MadupPinket/ket-bot)
- [Ketbot v2 source code](https://github.com/MadupPinket/ket-bot-v2)
- [Direct Line REST API 3.0(한국어)](https://blogs.msdn.microsoft.com/eva/?p=12625)
- [Dialog를 사용하여 대화의 흐름 만들기(한국어)](https://blogs.msdn.microsoft.com/eva/?p=12625)
- [상태저장을 위한 Bot State Service(한국어)](https://blogs.msdn.microsoft.com/eva/?p=12715)