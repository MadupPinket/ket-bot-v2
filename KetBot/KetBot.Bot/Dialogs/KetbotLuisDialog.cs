using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Luis.Models;
using System.Text.RegularExpressions;

namespace KetBot.Bot.Dialogs
{
    [LuisModel("2eafd60f-83ec-465a-bf57-634b725c266d", "50def8ad402f452697bf75a2ec2c8a7a")]
    [Serializable]
    public class KetbotLuisDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"None: "
                + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
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