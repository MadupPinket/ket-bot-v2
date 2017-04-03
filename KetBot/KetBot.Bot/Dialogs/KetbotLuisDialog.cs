using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Luis.Models;
using System.Text.RegularExpressions;
using KetBot.Data;
using KetBot.Data.Model;
using Newtonsoft.Json;

namespace KetBot.Bot.Dialogs
{
    [LuisModel("2eafd60f-83ec-465a-bf57-634b725c266d", "50def8ad402f452697bf75a2ec2c8a7a")]
    [Serializable]
    public class KetbotLuisDialog : LuisDialog<object>
    {
        //private IKetbotMongoRepository ketbotRepository;

        //public KetbotLuisDialog(IKetbotMongoRepository repository)
        //{
        //    ketbotRepository = repository;
        //}

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"None: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));

            KetBotResponse doc = new KetBotResponse
            {
                message = "로그아웃 방법은 '핀켓 앱 실행'-'사용자설정'-'나의 정보' 에 들어가셔서 로그아웃 버튼을 누르시면 된답니다.",
                attachments = new Attachment[]
                {
                    new Attachment
                    {
                        contentType = "imgage/png",
                        contentUrl = "https://fb-s-a-a.akamaihd.net/h-ak-xfp1/v/t31.0-8/14753331_1662104677413221_4328329874035870695_o.png?oh=7ecf85bcb515047af565a4b6c301ae7b&oe=5956D4ED&__gda__=1499037542_d1bb07172ac20cbd5b52f1cd7c480d76",
                        name = "핀켓 포인트 모으는 방법"
                    },
                    new Attachment
                    {
                        contentType = "imgage/png",
                        contentUrl = "https://fb-s-c-a.akamaihd.net/h-ak-xfp1/v/t1.0-9/14713732_1662104684079887_3609545804954456303_n.png?oh=3183487e33b1fc99d342d13bfab5fcd7&oe=5998EFF4&__gda__=1499872691_4edcfd11a1f04d93feccbfc5fbba9aac",
                        name = "핀켓 포인트 모으는 방법 2"
                    }
                    ,
                    new Attachment
                    {
                        contentType = "imgage/png",
                        contentUrl = "https://scontent-hkg3-1.xx.fbcdn.net/v/t1.0-9/14732201_1662104687413220_4143117773691462150_n.jpg?oh=70bb0609eed45c3bf0c7074e45cff3f0&oe=595D18E3",
                        name = "핀켓 포인트 모으는 방법 3"
                    }
                }
            };

            await context.PostAsync(JsonConvert.SerializeObject(doc));
            context.Wait(MessageReceived);
        }

        [LuisIntent("계정 변경 요청")]
        public async Task ChangeAccount(IDialogContext context, LuisResult result)
        {
            string message = $"계정 변경 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("계정 탈퇴 요청")]
        public async Task DeleteAccount(IDialogContext context, LuisResult result)
        {
            string message = $"계정 탈퇴 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("고객센터 알림 요청")]
        public async Task CSCenterAlert(IDialogContext context, LuisResult result)
        {
            string message = $"고객센터 알림 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("광고 적립/미적립 오류")]
        public async Task ADError(IDialogContext context, LuisResult result)
        {
            string message = $"광고 적립/미적립 오류: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("광고적립 요청")]
        public async Task ADSaving(IDialogContext context, LuisResult result)
        {
            string message = $"광고적립 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("기능 기타 요청")]
        public async Task FunctionEtc(IDialogContext context, LuisResult result)
        {
            string message = $"기능 기타 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("기능 방법 요청")]
        public async Task FunctionHowTo(IDialogContext context, LuisResult result)
        {
            string message = $"기능 방법 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("기능 오류 요청")]
        public async Task FunctionError(IDialogContext context, LuisResult result)
        {
            string message = $"기능 오류 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("멤버십 기타 요청")]
        public async Task MembershipEtc(IDialogContext context, LuisResult result)
        {
            string message = $"멤버십 기타 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("멤버십 방법 요청")]
        public async Task MembershipHowTo(IDialogContext context, LuisResult result)
        {
            string message = $"멤버십 방법 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("상품 구매 방법 요청")]
        public async Task HowToPurchase(IDialogContext context, LuisResult result)
        {
            string message = $"상품 구매 방법 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("상품 기타 요청")]
        public async Task ProductEtc(IDialogContext context, LuisResult result)
        {
            string message = $"상품 기타 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("상품 방법 요청")]
        public async Task ProductHowTo(IDialogContext context, LuisResult result)
        {
            string message = $"상품 방법 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("상품 삭제 요청")]
        public async Task ProductDelete(IDialogContext context, LuisResult result)
        {
            string message = $"상품 삭제 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("상품 오류 요청")]
        public async Task ProductError(IDialogContext context, LuisResult result)
        {
            string message = $"상품 오류 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("상품 유효기간 만료 요청")]
        public async Task ProductExpired(IDialogContext context, LuisResult result)
        {
            string message = $"상품 유효기간 만료 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("상품 취소 요청")]
        public async Task ProductCancel(IDialogContext context, LuisResult result)
        {
            string message = $"상품 취소 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("상품권 구매 방법 요청")]
        public async Task GiftCardPurchase(IDialogContext context, LuisResult result)
        {
            string message = $"상품권 구매 방법 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("상품권 기타 요청")]
        public async Task GiftCardEtc(IDialogContext context, LuisResult result)
        {
            string message = $"상품권 기타 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("상품권 방법 요청")]
        public async Task GiftCardHowTo(IDialogContext context, LuisResult result)
        {
            string message = $"상품권 방법 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("상품권 삭제 요청")]
        public async Task GiftCardDelete(IDialogContext context, LuisResult result)
        {
            string message = $"상품권 삭제 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("상품권 오류 요청")]
        public async Task GiftCardError(IDialogContext context, LuisResult result)
        {
            string message = $"상품권 오류 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("상품권 유효기간 만료 요청")]
        public async Task GiftCardExpired(IDialogContext context, LuisResult result)
        {
            string message = $"상품권 유효기간 만료 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("상품권 취소 요청")]
        public async Task GiftCardCancel(IDialogContext context, LuisResult result)
        {
            string message = $"상품권 취소 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("잠금화면 미적립 요청")]
        public async Task LockScreenUnsaved(IDialogContext context, LuisResult result)
        {
            string message = $"잠금화면 미적립 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("잠금화면 삭제 요청")]
        public async Task LockScreenDelete(IDialogContext context, LuisResult result)
        {
            string message = $"잠금화면 삭제 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("잠금화면 오류 요청")]
        public async Task LockScreenError(IDialogContext context, LuisResult result)
        {
            string message = $"잠금화면 오류 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("잠금화면 적립 요청")]
        public async Task LockScreenSaving(IDialogContext context, LuisResult result)
        {
            string message = $"잠금화면 적립 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("친구추천 미적립 요청")]
        public async Task RecommendFriendUnsaved(IDialogContext context, LuisResult result)
        {
            string message = $"친구추천 미적립 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("친구추천 방법 요청")]
        public async Task RecommendFriendHowTo(IDialogContext context, LuisResult result)
        {
            string message = $"친구추천 방법 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("친구추천 오류 요청")]
        public async Task RecommendFriendError(IDialogContext context, LuisResult result)
        {
            string message = $"친구추천 오류 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("친구추천 적립 요청")]
        public async Task RecommendFriendSaving(IDialogContext context, LuisResult result)
        {
            string message = $"친구추천 적립 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("친구추천매체 미적립 요청")]
        public async Task RecommendFriendMediaUnSaved(IDialogContext context, LuisResult result)
        {
            string message = $"친구추천매체 미적립 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("친구추천매체 방법 요청")]
        public async Task RecommendFriendMediaHowTo(IDialogContext context, LuisResult result)
        {
            string message = $"친구추천매체 방법 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("친구추천매체 오류 요청")]
        public async Task RecommendFriendMediaError(IDialogContext context, LuisResult result)
        {
            string message = $"친구추천매체 오류 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("친구추천매체 적립 요청")]
        public async Task RecommendFriendMediaSaving(IDialogContext context, LuisResult result)
        {
            string message = $"친구추천매체 적립 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("포인트 기타 요청")]
        public async Task PointEtc(IDialogContext context, LuisResult result)
        {
            string message = $"포인트 기타 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("포인트 유효기간 만료 요청")]
        public async Task PointExpired(IDialogContext context, LuisResult result)
        {
            string message = $"포인트 유효기간 만료 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("포인트 통합 미적립 요청")]
        public async Task PointUnsaving(IDialogContext context, LuisResult result)
        {
            string message = $"포인트 통합 미적립 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("포인트 통합 오류 요청")]
        public async Task PointSavingError(IDialogContext context, LuisResult result)
        {
            string message = $"포인트 통합 오류 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("포인트 통합 적립 요청")]
        public async Task PointSavingRequest(IDialogContext context, LuisResult result)
        {
            string message = $"포인트 통합 적립 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("포인트 통합 취소 요청")]
        public async Task PointSavingCencel(IDialogContext context, LuisResult result)
        {
            string message = $"포인트 통합 취소 요청: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        //private string RemoveSpaceOnEntity(string entity)
        //{
        //    Regex regex = new Regex(); 

        //    return entity;
        //}



    }

}