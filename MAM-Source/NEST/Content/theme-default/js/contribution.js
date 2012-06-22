function updatePaymentForm()
{
    var value = $("input[name=payment]:checked").val();
    
    if (value != "echeck")
    {
        $("#echeck-info").hide();
        $("#cc-info").show();
    } else
    {
        $("#cc-info").hide();
        $("#echeck-info").show();
    }
}

function popUpCscInfo()
{
    window.open('https://secure.piryx.com/donate/card-security-code', 'name', 'height=460,width=460');
    
    return false;
}        

function popUpSecurityNotice()
{
    window.open('https://secure.piryx.com/donate/security', 'name', 'height=270,width=460');
    
    return false;
}

function fillBillingInfo()
{
    setValue("#BillingCountryCode", "#CountryCode");
    setValue("#billingAddress1", "#address1");
    setValue("#billingAddress2", "#address2");
    setValue("#billingCity", "#city");
    setValue("#billingState", "#state");
    setValue("#billingZip", "#zip");
    
    $("#BillingCountryCode").change();
}

function setValue(id1, id2)
{
    $(id1).val($(id2).val());
}

function getSelectedAmount()
{
    var amountVal = $("input[name=amount]:checked").val();
    
    if (amountVal == "custom")
    {
        var customAmountVal = $("#customAmount").val();
        var customAmount =  parseFloat(customAmountVal);
        return isNaN(customAmount) ? 0 : customAmount;
    }
    
    var amount = parseFloat(amountVal)
    return isNaN(amount) ? 0 : amount;
}

function updateSubscriptionAmount()
{
    var amount = getSelectedAmount();
        
    $(".selected-amount").text("$" + amount);
    $("#annual-amount").text("$" + amount);
    $("#semiannual-amount").text(createAmountString(amount / 2));
    $("#quarterly-amount").text(createAmountString(amount / 4));
    $("#monthly-amount").text(createAmountString(amount / 12));
}

function createAmountString(amount)
{
    amount = (amount * 100).toFixed(0);
    
    return "$" + (amount / 100).toFixed(2);
    
}

var twitter = {
    IncreaseCount : function(DonationpageUrl) {
        $.ajax({ 
            url: "/twitter/tweet", 
            type: "POST", 
            data: { "DonationPageUrl": DonationpageUrl },
            success: function(statData) {
                if (statData == 1) 
                {
                    var count = parseInt($('#tweetcount').text());
                    $('#tweetcount').text(count + 1);
                }
            }
        });
    },
    
    Share : function(url) 
    { 
        window.open(url, '_blank', 'toolbar=0, status=0, width=796, height=436'); 
    } 
};


$(document).ready(function() {
    $("input[type=text],select").focus(function() {
        $(this).addClass("focus");
    }).blur(function() {
        $(this).removeClass("focus");
    });

    $("#customAmount").focus(function(){
        $("input[name=amount]").val(["custom"]);
    });
    $("input[name=payment]").click(function() {
        updatePaymentForm();
    });
    $("#billingSameAsHome").click(function() 
    {             
        if ($(this).attr("checked")) 
        { 
            fillBillingInfo(); 
        }
    });
    $("input[name=amount],#customAmount").click(function() {
        updateSubscriptionAmount();
    });
    $("#customAmount").change(function() {
        updateSubscriptionAmount();
    });
    $("#scheduled-dates .remove").click(function() {
        $(this).parent().remove();
    });
    $("#add-scheduled-date").click(function() {
        var content = $("<div class=\"scheduled-date\"><input type=\"text\" name=\"ScheduledDates\" class=\"date\" /> <a class=\"remove\"><img src=\"/images/schedule-remove.gif\" alt=\"Remove\" /></a></div>");
        
        content.find(".remove").click(function() {
            $(this).parent().remove();
        });
        
        content.find(".date").datepicker();
    });

    $("#share-dialog .facebook-share-dialog a.skip").click(function() {
        $("input[name=ShareOnFacebook]").removeAttr("checked");
        $("#share-dialog .facebook-share-dialog").hide();
        $("#share-dialog .thank-you-dialog").show();
        $("#create-comment-form").submit();
        return false;
    });

    $("#create-comment-form .button").click(function() {
        var shareOnFacebook = $("input[name=ShareOnFacebook]").is(":checked");
        
        if (shareOnFacebook)
        {
            $.fn.colorbox({ width: 440, inline: true, href: "#share-dialog", overlayClose: false, escKey: false });
            return false;
        } else {
            $("#share-dialog .facebook-share-dialog").hide();
            $("#share-dialog .thank-you-dialog").show();
            $("#create-comment-form").submit();
            $.fn.colorbox({ width: 440, inline: true, href: "#share-dialog", overlayClose: false, escKey: false });
            return false;
        }
        
        return true;
    });

	$("a.connect-to-facebook").click(function() {
        var url = $(this).attr("href");
        $(this).attr("href", "#").attr("target", "_self");
        var w = window.open(url, "PGSConnectToFacebook", "width=1000,height=550,menubar=no,toolbar=no");
        var watchClose = setInterval(function() {
            try {
                if (w.closed) {
                    clearTimeout(watchClose);
                    $("#share-dialog .facebook-share-dialog").hide();
                    $("#share-dialog .thank-you-dialog").show();
                    $("#create-comment-form").submit();
                }
            } catch (e) {}
        }, 200);

        return false;
    });
    
    $("a.retweet").click(function() {
        var pageUrl = $('#DonationPageUrl').val();
        var tweetUrl = $(this).attr("href");
        twitter.Share(tweetUrl);
        twitter.IncreaseCount(pageUrl);
        return false;
    });
	
    updateSubscriptionAmount();
    updatePaymentForm();
});

