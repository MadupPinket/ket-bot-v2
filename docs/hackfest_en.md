Begin with an intro statement with the following details:

- Solution overview
 
- Key technologies used
 
- Core Team: Names, roles and Twitter handles 


매드업은 2011년 설립된 마케팅 전문기업으로 핀켓(FINKET)이라는 Mobile Finance Service를 운영하고 있습니다. 핀켓 앱은 스마트폰의 잠금화면으로 신뢰성 있는 금융 기사와 포인트 통합 그리고 편리한 멤버십 적립과 개인 금융 서비스를, 광고주에게는 타겟 금융 광고 플랫폼을 제공합니다. 특히 카드 적립포인트나 상품권과 같이 현금처럼 사용할 수 있는 포인트를 다루기 때문에 고객들로 부터 문의사항이 많은 편입니다. 

고객들의 문의사항이나 불만사항들을 분석하고 향후 일부 CS(Customer Satisfaction)업무를 챗봇을 통해서 지원하는 프로젝트를 이번 Hackfest를 통해서 검증해 보기로 하였습니다. Microsoft Bot Framework를 사용하여 챗봇을 구현하고 Microsoft Azure의 DocumentDB, Search 등의 기능을 백엔드에서 사용하여 데이터를 처리했습니다. 특히 고객들과의 자연스러운 채팅을 구현하기 위해 Microsoft Cognitive Services의 자연어 처리 서비스인 LUIS(Language Understanding Intelligent Service)를 사용했습니다. 


Hackfest 멤버
- Edgar Kim: Madup, CTO
- 송우석: Madup, CDO
- 이봉진: Madup, Software Engineer
- 이주민: Madup, Software Engineer
- 오일석: Microsoft, Technical Evangelist
- 류혜원: Microsoft, Audience Evangelism Manager



## Customer profile ##
This section will contain general information about the customer, including the following:

- Company name and URL

- Company description

- Company location

- What are their product/service offerings?


## 고객사 ## 

[MADUP Inc.](http://madup.com/) is the fastest growing mobile app performance marketing startup in South Korea with a 30% sales growth in 2016 after its establishment in 2015. They have excellent in-house data scientists and developers that are proficient in business analysis and opportunities and big data analysis.

It is operating an app called [FinKet](https://play.google.com/store/apps/details?id=com.madup.pocket) as well as mobile app marketing services. This app provides a service that allows a user to integrate various credit card points and provides targeted finance advertising platforms for advertisers. It was ranked as the second most downloaded app in the lifestyles category of webstore in South Korea and it featured many times in finance area.
 
## Problem statement ##


This section will define the problem(s)/challenges that the customer wants to address with a CaaP solution. Include things like costs, customer experience, etc.
 
*If you’d really like to make your write-up pop, include a customer quote that highlights the customer’s problem(s)/challenges. Attribute all quotes with Name, Title, Company.*


 
## Solution and steps ##


The majority of your win artifacts will be included in this section, including (but not limited to) the following: Source code snippets, pictures, drawings, architectural diagrams, value stream mappings, and demo videos.

This section should include the following details:

- What was worked on and what problem it helped solve.

- Architecture diagram/s (**required**). Example below:

 ![IoT Architecture Diagram](/images/templates/caaparchitecture.png)

**Directions for adding images:**

1. Create a folder for your project images in the “images” folder in the GitHub repo files. This is where you will add all of the images associated with your write-up.
 
2. Add links to your images using the following absolute path:

  `![Description of the image]({{site.baseurl}}/images/projectname/myimage.png)`
    
  Here’s an example: 

  `![Value Stream Mapping]({{site.baseurl}}/images/orckestra/orckestra2.jpg)`

 Note that capitalization of the file name and the file extension must match exactly for the images to render properly.

*If you’d really like to make your write-up pop, include a customer quote that highlights the solution. Attribute all quotes with Name, Title, Company.*


## Technical delivery ##
This section will include the following details of how the solution was implemented:

- Bot Patterns

- Core Bot Capabilities

- Bot Intelligence

	- Cognitive Services

	- Azure Search


- Technology Integration

	- Azure Storage, Compute or services

	- Microsoft Canvas, 3rd Party Channels

- SDKs used, languages, etc.

- Code artifacts

- Pointers to references or documentation

- Learnings from the Microsoft team and the customer team

*If you’d really like to make your write-up pop, include a customer quote that highlights the solution. Attribute all quotes with Name, Title, Company.*


 
## Conclusion ##

This section will briefly summarize the technical story with the following details included:

- Measurable impact/benefits resulting from the implementation of the solution.

- General lessons:

  - Insights the team came away with

  - What can be applied or reused for other environments or customers?

- Opportunities going forward:

  - Details on how the customer plans to proceed or what more they hope to accomplish

*If you’d really like to make your write-up pop, include a customer quote highlighting impact, benefits, general lessons, and/or opportunities.*


## Additional resources ##
In this section, include a list of links to resources that complement your story, including (but not limited to) the following:

- Documentation

- Blog posts

- GitHub repos

- Etc…