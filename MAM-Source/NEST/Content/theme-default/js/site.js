function _UIsAlphaNum(c) {
    if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
        return true;
    return false;
}

function _UValidEmail(v) {
    // BETA2: We should use a good Regular Expression to do this, however, I can't seem to find one.
    //       On the server, we can do a better job than here, so, let's just be a little forgiven here.

    function IsValidEmailChar(c) {
        if (_UIsAlphaNum(c))
            return true;
        if (c == '-' || c == '_' || c == '%' || c == '.' || c == '+')
            return true;
        return false;
    }

    function IsValidEmailPrefix(ep) {
        if (!ep || ep.length > 64)
            return false;

        var c = ep.charAt(0);
        if (!_UIsAlphaNum(c) && c != '_')
            return false;
        for (var i = 1; i < ep.length - 1; i++) {
            if (!IsValidEmailChar(ep.charAt(i)))
                return false;
        }
        var c = ep.charAt(ep.length - 1);
        if (!_UIsAlphaNum(c) && c != '_')
            return false;
        return true;
    }

    function IsValidHost(h) {
        if (!h || h.length > 64)
            return false;

        var c = h.charAt(0);
        if (!_UIsAlphaNum(c) && c != '_')
            return false;

        for (var i = 1; i < h.length; i++) {
            c = h.charAt(i);
            if(!_UIsAlphaNum(c) && c != '-' && c != '.')
                return false;
        }

        return true;
    }


    if (!v || v.length < 6 || v.length > 128)
        return false;

    var atp = v.indexOf('@');
    // Must have an @ and it cannot be on the beginning or the end
    if (atp == -1 || atp == 0 || atp == (v.length - 1))
        return false;

    if (v.indexOf('@', atp + 1) != -1)
        return false; // Two '@'

    var esp = v.substr(0, atp);
    if (!IsValidEmailPrefix(esp))
        return false;

    var host = v.substr(atp + 1);
    if(!IsValidHost(host))
        return false;

    return true;
}



function rf() 
{
    var f = $('#Footer');
    f.width($(window).width());
    f.css('top', $(window).height() - 5 - f.height());
}
$(rf);
$(window).bind('resize', rf);
