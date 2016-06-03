if (!window.jGroupdocs)
window.jGroupdocs = {};
window.jGroupdocs.stringExtensions = {
format: function (sourceString) {
var s = sourceString,
i = arguments.length;
while (--i) {
s = s.replace(new RegExp('\\{' + (i - 1) + '\\}', 'gm'), arguments[i]);
}
return s;
},
trim: function (string, target) {
var regex = new RegExp("^[" + target + "]+|[" + target + "]+$", "g");
return string.replace(regex, '');
},
trimStart: function (string, target) {
var regex = new RegExp("^[" + target + "]+", "g");
return string.replace(regex, '');
},
trimEnd: function (string, target) {
var regex = new RegExp("[" + target + "]+$", "g");
return string.replace(regex, '');
},
getAccentInsensitiveRegexFromString: function (text) {
var accents = [
["A", 'ÀÁÂÃÄÅÆ'],
["C", 'Ç'],
["E", 'ÈÉÊËÆ'],
["I", 'ÌÍÎÏ'],
["N", 'Ñ'],
["O", 'ÒÓÔÕÖØ'],
["S", 'ß'],
["U", 'ÙÚÛÜ'],
["Y", 'Ÿ'],
["У", 'Ў'], // cyrilllic
["a", 'àáâãäåæ'],
["c", 'ç'],
["e", 'èéêëæ'],
["i", 'ìíîï'],
["n", 'ñ'],
["o", 'òóôõöø'],
["s", 'ß'],
["u", 'ùúûü'],
["y", 'ÿ'],
["у", 'ў'] // cyrilllic
];
var charNum;
var charsToBeReplaced = "";
for (charNum = 0; charNum < accents.length; charNum++)
charsToBeReplaced += accents[charNum][0];
var charsRegex = new RegExp("[" + charsToBeReplaced + "]", "g");
function makeComp(input) {
return input.replace(charsRegex, function (c) {
var replacementChars = null;
for (charNum = 0; charNum < accents.length; charNum++) {
if (accents[charNum][0] == c) {
replacementChars = accents[charNum][1];
break;
}
}
if (replacementChars === null)
replacementChars = "";
return '[' + c + replacementChars + ']';
});
};
return makeComp(text);
},
_padWithLeadingZeros: function (string) {
return new Array(5 - string.length).join("0") + string;
},
_unicodeCharEscape: function (charCode) {
return "\\u" + this._padWithLeadingZeros(charCode.toString(16));
},
unicodeEscape: function (string) {
var self = this;
return string.split("")
.map(function (character) {
var charCode = character.charCodeAt(0);
return charCode > 127 ? self._unicodeCharEscape(charCode) : character;
})
.join("");
}
};
window.jGroupdocs.http = {
splitUrl: (function () {
var regex = new RegExp("(\\w+)://([^/]+)([^\?]*)([\?].+)?");
return function (url) {
var matches = url.match(regex);
var path = (matches.length > 3 ? matches[3] : null);
var query = (matches.length > 4 ? matches[4] : null);
return {
"schema": matches[1],
"authority": (matches.length > 2 ? matches[2] : null),
"path": path,
"query": query,
"queryDict": $.fn.q(query),
"pathAndQuery": (query ? (path + query) : path)
};
};
})()
};
JsInject={Container:function(){this.serviceEntries=[];this.disposables=[]}};JsInject.Container.prototype.Resolve=function(a,c,b,d,e,f,g,h,i,j){return this.ResolveInternal(a,!0,c,b,d,e,f,g,h,i,j)};JsInject.Container.prototype.TryResolve=function(a,c,b,d,e,f,g,h,i,j){return this.ResolveInternal(a,!1,c,b,d,e,f,g,h,i,j)};
JsInject.Container.prototype.RegisterInternal=function(a,c,b,d){if(this.RegisteredInternal(a))throw"Factory with name '"+a+"' alredy registered";this.serviceEntries[a]={factory:c,scope:b,owner:d,instance:null}};JsInject.Container.prototype.Dispose=function(){for(var a in this.disposables)this.disposables[a].Dispose()};
JsInject.Container.prototype.ResolveInternal=function(a,c,b,d,e,f,g,h,i,j,k){if(!this.RegisteredInternal(a))if(c)throw"Factory with name '"+a+"' is not registered";else return null;a=this.serviceEntries[a];if(a.scope==="container"){if(a.instance===null)a.instance=this.CreateInstanceInternal(a.factory,a.owner,b,d,e,f,g,h,i,j,k);return a.instance}return this.CreateInstanceInternal(a.factory,a.owner,b,d,e,f,g,h,i,j,k)};
JsInject.Container.prototype.CreateInstanceInternal=function(a,c,b,d,e,f,g,h,i,j,k){a=a(this,b,d,e,f,g,h,i,j,k);c==="container"&&typeof a.Dispose==="function"&&this.disposables.push(a);return a};JsInject.Container.prototype.RegisteredInternal=function(a){return this.serviceEntries[a]!==void 0};JsInject.Registration=function(a,c){this.name=a;this.factory=c;this.scope="none";this.owner="consumer"};JsInject.Registration.prototype.Reused=function(){this.scope="container";this.Owned();return this};
JsInject.Registration.prototype.Owned=function(){this.owner="container";return this};JsInject.ContainerBuilder=function(){this.registrations=[]};JsInject.ContainerBuilder.prototype.Register=function(a,c){var b=new JsInject.Registration(a,c);this.registrations.push(b);return b};JsInject.ContainerBuilder.prototype.Create=function(){var a=new JsInject.Container,c;for(c in this.registrations){var b=this.registrations[c];a.RegisterInternal(b.name,b.factory,b.scope,b.owner)}return a};
JsInject.Container.prototype.Register=function(a,c,b){a=new JsInject.Registration(a,c);b&&a.Reused();this.RegisterInternal(a.name,a.factory,a.scope,a.owner)};
if (!window.jSaaspose)
window.jSaaspose = {};
if (!window.Container) {
window.Container = new JsInject.Container();
Container.Register("Cacher", function (c) { return $.jCacher; }, true);
Container.Register("Rx.Observable", function (c) { return Rx.Observable; }, true);
Container.Register("RequestObservable", function (c) { return $.ajaxAsObservable; }, true);
Container.Register("AsyncSubject", function (c) { return new Rx.AsyncSubject(); }, false);
var host = window.location.hostname + (window.location.port ? ':' + window.location.port : '');
var applicationPath = $.ui.groupdocsViewer.prototype.applicationPath;
if (applicationPath == "/") {
applicationPath = window.location.protocol + "//" + host+"/";
$.ui.groupdocsViewer.prototype.applicationPath = applicationPath;
}
if (applicationPath != "/") {
var slashPosition = applicationPath.indexOf("//");
if (slashPosition == -1) {
var newApplicationPath = window.location.protocol + "//" + host + applicationPath;
$.ui.groupdocsViewer.prototype.applicationPath = newApplicationPath;
}
var hostNamePosition = slashPosition + 2;
if (applicationPath.indexOf(host, hostNamePosition) != hostNamePosition)
$.ui.groupdocsViewer.prototype.isWorkingCrossDomain = true;
}
Container.Register("PortalService", function (c) {
return new jSaaspose.PortalService($.ui.groupdocsViewer.prototype.applicationPath,
$.ui.groupdocsViewer.prototype.useHttpHandlers,
$.ui.groupdocsViewer.prototype.isWorkingCrossDomain);
}, true);
//Container.Register("HttpProvider", function (c) { return jSaaspose.http; }, true);
Container.Register("HttpProvider", function (c) {
return {
buildUrl: function (baseUrl, relativeUrl, params) {
var url = jGroupdocs.stringExtensions.trimEnd(baseUrl, '/');
if (relativeUrl && relativeUrl.length > 0) {
url += '/' + jGroupdocs.stringExtensions.trimStart(relativeUrl, '/');
}
if (params) {
url += (url.indexOf('&') != -1 || url.indexOf('?') != -1 ? '&' : '?') + jQuery.param(params);
}
return url;
},
signUrl: function () { return ""; }
};
}, true);
}
/*
* MIT LICENSE
* Copyright (c) 2009-2011 Devon Govett.
*
* Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
* documentation files (the "Software"), to deal in the Software without restriction, including without limitation
* the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
* and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all copies or substantial portions
* of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO
* THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
* TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
(function($) {
$.fn.ellipsis = function(enableUpdating){
var s = document.documentElement.style;
if (!('textOverflow' in s || 'OTextOverflow' in s)) {
return this.each(function(){
var el = $(this);
if(el.css("overflow") == "hidden"){
var originalText = el.html();
var w = el.width();
var t = $(this.cloneNode(true)).hide().css({
'position': 'absolute',
'width': 'auto',
'overflow': 'visible',
'max-width': 'inherit'
});
el.after(t);
var text = originalText;
while(text.length > 0 && t.width() > el.width()){
text = text.substr(0, text.length - 1);
t.html(text + "...");
}
el.html(t.html());
t.remove();
if(enableUpdating == true){
var oldW = el.width();
setInterval(function(){
if(el.width() != oldW){
oldW = el.width();
el.html(originalText);
el.ellipsis();
}
}, 200);
}
}
});
} else return this;
};
})(jQuery);
(function ($) {
$.fn.innerTip = function (options) {
return this.each(function () {
var e = $(this);
e.focusin(function () {
if (e.hasClass('empty')) {
e.val('');
e.removeClass('empty');
}
});
e.focusout(function () {
if (e.val() == '') {
e.val(options.text);
e.addClass('empty');
}
});
e.bind('reset', function () {
e.val(options.text);
e.addClass('empty');
});
e.val(options.text);
e.addClass('empty');
})
};
})(jQuery);
(function ($) {
var corners = {
classes: []
}
$.fn.corners = function (options) {
return this.each(function () {
var e = $(this);
if ($.inArray(options.id, corners.classes) === -1) {
corners.classes.push(options.id);
$('body').append('<style type="text/css">' +
'.' + options.id + '>' + ' .c_tl_' + options.id + ', .' + options.id + '>' + ' .c_tr_' + options.id + ', .' +
options.id + '>' + ' .c_bl_' + options.id + ', .'  + options.id + '>' + ' .c_br_'  + options.id +
' { width:' + options.r + ';height:' + options.r + '; position: absolute; } ' +
'.c_tl_' + options.id + ' {' +
'background: url(/images/corners/c_tl_' + options.id + '.png) top left no-repeat;top: -1px;left: -1px; } ' +
'.c_tr_' + options.id + ' {' +
'background: url(/images/corners/c_tr_' + options.id + '.png) top right no-repeat;top: -1px;right: -1px; } ' +
'.c_bl_' + options.id + ' {' +
'background: url(/images/corners/c_bl_' + options.id + '.png) bottom left no-repeat;bottom: -1px;left: -1px; } ' +
'.c_br_' + options.id + ' {' +
'background: url(/images/corners/c_br_' + options.id + '.png) bottom right no-repeat;bottom: -1px;right: -1px; } ' +
'</style>');
}
e.css({ position: 'relative' });
e.prepend('<div class="c_tl_' + options.id + '"></div><div class="c_tr_' + options.id + '"></div>');
e.append('<div class="c_bl_' + options.id + '"></div><div class="c_br_' + options.id + '"></div>');
})
};
})(jQuery);
//hitch plugin
(function ($) {
$.fn.hitch = function (ev, fn, scope, data) {
return this.bind(ev, data, function () {
return fn.apply(scope || this, Array.prototype.slice.call(arguments));
});
};
})(jQuery);
//convert JSON data to string representation
(function ($) {
$.fn.q = function (q) {
var result = {};
if (q)
{
var q = q.replace(/^\?/, '').replace(/\&$/, '');
$.each(q.split('&'), function () {
var key = this.split('=')[0];
var val = this.split('=')[1];
// convert floats
if (/^[0-9.]+$/.test(val)) {
val = parseFloat(val);
}
// ingnore empty values
if (val) {
result[key] = val;
}
});
}
return result;
};
})(jQuery);
//buttons and links disabler/enabler
(function ($) {
var killEvent = function (e) {
e.preventDefault();
};
var killAction = function (e) {
e.click(killEvent);
if (e.is("input[type='submit'],input[type='button']")) {
e.attr("disabled", "disabled");
}
};
var disable = function (e, cl, tip) {
var c = e.data("clone");
if (!c) {
c = e.clone(false);
$.each(c[0].attributes, function(index, attr) {
if (attr != null && attr.name != "class") {
c.attr(attr.name, "");
}
});
if (cl != "") {
c.addClass(cl);
}
killAction(c);
e.data("clone", c);
e.after(c);
}
c.attr("title", tip);
e.hide();
c.show();
};
var enable = function (e) {
var clone = e.data("clone");
if (clone) {
e.show();
clone.hide();
}
};
$.fn.activator = function (options) {
return this.each(function () {
var e = $(this);
if (options.action == "enable") {
enable(e);
return;
}
if (options.action == "disable"){
disable(e, options.cl, options.tip);
}
})
};
$.fn.isEnable = function() {
var e = $(this);
var clone = e.data('clone');
if (clone && clone.is(':visible')){
return false;
}
return true;
};
})(jQuery);
// Simple Set Clipboard System
// Author: Joseph Huckaby
var ZeroClipboard = {
version: "1.0.7",
clients: {}, // registered upload clients on page, indexed by id
moviePath: 'ZeroClipboard.swf', // URL to movie
nextId: 1, // ID of next movie
$: function (thingy) {
// simple DOM lookup utility function
if (typeof (thingy) == 'string') thingy = document.getElementById(thingy);
if (!thingy.addClass) {
// extend element with a few useful methods
thingy.hide = function () { this.style.display = 'none'; };
thingy.show = function () { this.style.display = ''; };
thingy.addClass = function (name) { this.removeClass(name); this.className += ' ' + name; };
thingy.removeClass = function (name) {
var classes = this.className.split(/\s+/);
var idx = -1;
for (var k = 0; k < classes.length; k++) {
if (classes[k] == name) { idx = k; k = classes.length; }
}
if (idx > -1) {
classes.splice(idx, 1);
this.className = classes.join(' ');
}
return this;
};
thingy.hasClass = function (name) {
return !!this.className.match(new RegExp("\\s*" + name + "\\s*"));
};
}
return thingy;
},
setMoviePath: function (path) {
// set path to ZeroClipboard.swf
this.moviePath = path;
},
dispatch: function (id, eventName, args) {
// receive event from flash movie, send to client
var client = this.clients[id];
if (client) {
client.receiveEvent(eventName, args);
}
},
register: function (id, client) {
// register new client to receive events
this.clients[id] = client;
},
getDOMObjectPosition: function (obj, stopObj) {
// get absolute coordinates for dom element
var info = {
left: 0,
top: 0,
width: obj.width ? obj.width : obj.offsetWidth,
height: obj.height ? obj.height : obj.offsetHeight
};
//        while (obj && (obj != stopObj)) {
//            info.left += obj.offsetLeft;
//            info.top += obj.offsetTop;
//            obj = obj.offsetParent;
//        }
return info;
},
Client: function (elem) {
// constructor for new simple upload client
this.handlers = {};
// unique ID
this.id = ZeroClipboard.nextId++;
this.movieId = 'ZeroClipboardMovie_' + this.id;
// register client with singleton to receive flash events
ZeroClipboard.register(this.id, this);
// create movie
if (elem) this.glue(elem);
}
};
ZeroClipboard.Client.prototype = {
id: 0, // unique ID for us
ready: false, // whether movie is ready to receive events or not
movie: null, // reference to movie object
clipText: '', // text to copy to clipboard
handCursorEnabled: true, // whether to show hand cursor, or default pointer cursor
cssEffects: true, // enable CSS mouse effects on dom container
handlers: null, // user event handlers
glue: function (elem, appendElem, stylesToAdd) {
// glue to DOM element
// elem can be ID or actual DOM element object
this.domElement = ZeroClipboard.$(elem);
// float just above object, or zIndex 99 if dom element isn't set
var zIndex = 99;
if (this.domElement.style.zIndex) {
zIndex = parseInt(this.domElement.style.zIndex, 10) + 1;
}
if (typeof (appendElem) == 'string') {
appendElem = ZeroClipboard.$(appendElem);
}
else if (typeof (appendElem) == 'undefined') {
appendElem = document.getElementsByTagName('body')[0];
}
// find X/Y position of domElement
var box = ZeroClipboard.getDOMObjectPosition(this.domElement, appendElem);
// create floating DIV above element
this.div = document.createElement('div');
var style = this.div.style;
style.position = 'absolute';
style.left = '' + box.left + 'px';
style.top = '' + box.top + 'px';
style.width = '' + box.width + 'px';
style.height = '' + (box.height * 2) + 'px';
style.zIndex = zIndex;
if (typeof (stylesToAdd) == 'object') {
for (addedStyle in stylesToAdd) {
style[addedStyle] = stylesToAdd[addedStyle];
}
}
// style.backgroundColor = '#f00'; // debug
appendElem.appendChild(this.div);
this.div.innerHTML = this.getHTML(box.width, box.height);
},
getHTML: function (width, height) {
// return HTML for movie
var html = '';
var flashvars = 'id=' + this.id +
'&width=' + width +
'&height=' + height;
if (navigator.userAgent.match(/MSIE/)) {
// IE gets an OBJECT tag
var protocol = location.href.match(/^https/i) ? 'https://' : 'http://';
html += '<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="' + protocol + 'download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0" width="' + width + '" height="' + (height * 2) + '" id="' + this.movieId + '" align="middle"><param name="allowScriptAccess" value="always" /><param name="allowFullScreen" value="false" /><param name="movie" value="' + ZeroClipboard.moviePath + '" /><param name="loop" value="false" /><param name="menu" value="false" /><param name="quality" value="best" /><param name="bgcolor" value="#ffffff" /><param name="flashvars" value="' + flashvars + '"/><param name="wmode" value="transparent"/></object>';
}
else {
// all other browsers get an EMBED tag
html += '<embed id="' + this.movieId + '" src="' + ZeroClipboard.moviePath + '" loop="false" menu="false" quality="best" bgcolor="#ffffff" width="' + width + '" height="' + (height * 2) + '" name="' + this.movieId + '" align="middle" allowScriptAccess="always" allowFullScreen="false" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" flashvars="' + flashvars + '" wmode="transparent" />';
}
return html;
},
hide: function () {
// temporarily hide floater offscreen
if (this.div) {
this.div.style.left = '-2000px';
}
},
show: function () {
// show ourselves after a call to hide()
this.reposition();
},
destroy: function () {
// destroy control and floater
if (this.domElement && this.div) {
this.hide();
this.div.innerHTML = '';
var body = document.getElementsByTagName('body')[0];
try { body.removeChild(this.div); } catch (e) { ; }
this.domElement = null;
this.div = null;
}
},
reposition: function (elem) {
// reposition our floating div, optionally to new container
// warning: container CANNOT change size, only position
if (elem) {
this.domElement = ZeroClipboard.$(elem);
if (!this.domElement) this.hide();
}
if (this.domElement && this.div) {
var box = ZeroClipboard.getDOMObjectPosition(this.domElement);
var style = this.div.style;
style.left = '' + box.left + 'px';
style.top = '' + box.top + 'px';
}
},
setText: function (newText) {
// set text to be copied to clipboard
this.clipText = newText;
if (this.ready) this.movie.setText(newText);
},
addEventListener: function (eventName, func) {
// add user event listener for event
// event types: load, queueStart, fileStart, fileComplete, queueComplete, progress, error, cancel
eventName = eventName.toString().toLowerCase().replace(/^on/, '');
if (!this.handlers[eventName]) this.handlers[eventName] = [];
this.handlers[eventName].push(func);
},
setHandCursor: function (enabled) {
// enable hand cursor (true), or default arrow cursor (false)
this.handCursorEnabled = enabled;
if (this.ready) this.movie.setHandCursor(enabled);
},
setCSSEffects: function (enabled) {
// enable or disable CSS effects on DOM container
this.cssEffects = !!enabled;
},
receiveEvent: function (eventName, args) {
// receive event from flash
eventName = eventName.toString().toLowerCase().replace(/^on/, '');
// special behavior for certain events
switch (eventName) {
case 'load':
// movie claims it is ready, but in IE this isn't always the case...
// bug fix: Cannot extend EMBED DOM elements in Firefox, must use traditional function
this.movie = document.getElementById(this.movieId);
if (!this.movie) {
var self = this;
setTimeout(function () { self.receiveEvent('load', null); }, 1);
return;
}
// firefox on pc needs a "kick" in order to set these in certain cases
if (!this.ready && navigator.userAgent.match(/Firefox/) && navigator.userAgent.match(/Windows/)) {
var self = this;
setTimeout(function () { self.receiveEvent('load', null); }, 100);
this.ready = true;
return;
}
this.ready = true;
this.movie.setText(this.clipText);
this.movie.setHandCursor(this.handCursorEnabled);
break;
case 'mouseover':
if (this.domElement && this.cssEffects) {
this.domElement.addClass('hover');
if (this.recoverActive) this.domElement.addClass('active');
}
break;
case 'mouseout':
if (this.domElement && this.cssEffects) {
this.recoverActive = false;
if (this.domElement.hasClass('active')) {
this.domElement.removeClass('active');
this.recoverActive = true;
}
this.domElement.removeClass('hover');
}
break;
case 'mousedown':
if (this.domElement && this.cssEffects) {
this.domElement.addClass('active');
}
break;
case 'mouseup':
if (this.domElement && this.cssEffects) {
this.domElement.removeClass('active');
this.recoverActive = false;
}
break;
} // switch eventName
if (this.handlers[eventName]) {
for (var idx = 0, len = this.handlers[eventName].length; idx < len; idx++) {
var func = this.handlers[eventName][idx];
if (typeof (func) == 'function') {
// actual function reference
func(this, args);
}
else if ((typeof (func) == 'object') && (func.length == 2)) {
// PHP style object + method, i.e. [myObject, 'myMethod']
func[0][func[1]](this, args);
}
else if (typeof (func) == 'string') {
// name of function
window[func](this, args);
}
} // foreach event handler defined
} // user defined handler for event
}
};
/*
* jCacher - Client-side Cache Plugin for jQuery
* Version: 1.0.0 (2010-03-03)
*
* Author: Andreas Brantmo
* Website: http://plugins.jquery.com/project/jCacher
*
* Dual licensed under:
* MIT: http://www.opensource.org/licenses/mit-license.php
* GPL Version 2: http://www.opensource.org/licenses/gpl-3.0.html
*/
// moved to jGroupdocs.ArrayExtensions.js
// breaks Sharepoint ribbon when using using installable Viewer
//if (!Array.prototype.indexOf) {
//    Array.prototype.indexOf = function (elt /*, from*/) {
//        var len = this.length;
//        var from = Number(arguments[1]) || 0;
//        from = (from < 0)
//         ? Math.ceil(from)
//         : Math.floor(from);
//        if (from < 0)
//            from += len;
//        for (; from < len; from++) {
//            if (from in this &&
//          this[from] === elt)
//                return from;
//        }
//        return -1;
//    };
//}
(function($, undefined) {
// Create the cache manager and attach it to the
// global object, e.g jQuery.
$.jCacher = new function() {
// Save a reference to the current object
var cache = this;
// Reference to the current jQuery instance of
// the jCacher object.
var $this = $(this);
// Set current version
cache.version = "1.0.0";
// The number of items in the cache
cache.count = 0;
//var useLocalStorage = false;
// Id for the current setTimeout.
var currentTimeout;
// The key of the next item to be removed from the
// cache, based on last schedule.
var nextKey;
// Next scheduled check.
var nextCheck;
// Data storage object
var store = new storage(false);
// Adds the specified number of seconds
// to a date object.
var addMilliseconds = function(date, milliseconds) {
return new Date(date.getTime() + milliseconds);
};
// Internal function for removing an item from cache.
var removeItem = function(key, reason) {
var itm = store.getCacheItem(key);
if (key !== null && key !== undefined && itm !== null) {
cache.count--;
// Get dependency mappings for the cache item
var mappings = store.getDependencyMappings(key);
// Remove the cache item from storage
store.removeCacheItem(key);
// Trigger itemremoved event
onitemremoved(itm, reason);
// Loop through the mappings and request them to be removed
for (var i = 0; i < mappings.length; i++) {
removeItem(mappings[i], "dependencyChanged");
}
}
return itm !== undefined;
};
// Goes through all items in the cache and removes
// them if expired.
var validate = function() {
var now = new Date();
var items = store.getCacheItems();
var rebuildSchedule = false;
for (var i = 0; i < items.length; i++) {
var item = items[i];
if (item.expires <= now) {
rebuildSchedule = true;
removeItem(item.key, "expired");
}
}
// Rebuild the schedule if items were removed
if (rebuildSchedule) {
schedule();
}
};
// Calculates the next check
var schedule = function(item) {
// If no cacheitem is passed to the function,
// calculate next check based on all
// existing items in the cache.
if (item === undefined) {
nextCheck = null;
nextKey = null;
// Clear the current timeout
if (currentTimeout) {
clearTimeout(currentTimeout);
}
var items = store.getCacheItems();
// Calculate next expire based on existing cache items.
for (var i = 0; i < items.length; i++) {
var itm = items[i];
if (nextCheck) {
if (itm.expires < nextCheck) {
nextCheck = itm.expires;
nextKey = itm.key;
}
}
else {
nextCheck = itm.expires;
nextKey = itm.key;
}
}
if (nextCheck) {
setTimer();
}
else {
currentTimeout = null;
}
}
// If a cacheitem is passed to the function,
// set the timer to its expire value if it's
// earlier than nextCheck or if nextCheck is
// undefined.
else if (nextCheck == undefined || (nextCheck && item.expires < nextCheck)) {
// Clear the current timeout
if (currentTimeout) {
clearTimeout(currentTimeout);
}
nextCheck = item.expires;
setTimer();
}
};
var setTimer = function() {
if (nextCheck) {
var now = new Date();
// Calculate time in milliseconds from now until next check
var timeUntilNextCheck = nextCheck.getTime() - now.getTime() + 100;
// Init a setTimeout if next check is in the future
if (timeUntilNextCheck > 0) {
currentTimeout = setTimeout(validate, timeUntilNextCheck);
}
// Otherwise do the validation immediately
else {
validate();
}
}
}
// Triggers itemremoved event
var onitemremoved = function(item, reason) {
$this.trigger("itemremoved", [item, reason]);
};
cache.itemremoved = function(fn) {
$this.bind("itemremoved", fn);
};
// Adds a new item to the cache
cache.add = function(key, value, slidingExpiration, absoluteExpiration, dependencies, onRemoved) {
if (value !== undefined) {
// Increase item count if key is not already in the cache
//if (store.getCacheKeys().indexOf(key) == -1) {
if ($.inArray(key, store.getCacheKeys()) == -1) {
cache.count++;
}
// Calculate the expire date.
var expires;
if (slidingExpiration || absoluteExpiration) {
if (slidingExpiration) {
expires = addMilliseconds(new Date(), (slidingExpiration * 1000));
}
else if (absoluteExpiration) {
expires = absoluteExpiration;
}
}
// Register dependencies
if (dependencies) {
store.registerDependencies(key, dependencies);
}
var item = new cacheItem(key, value, expires, slidingExpiration)
// Adds the cache item to the cache.
store.addCacheItem(item);
// If the item is set to expire, rebuild the schedule, but
// only if it's earlier than nextCheck.
if (expires && (nextCheck === undefined || expires < nextCheck) || (nextKey == key || nextCheck === null)) {
schedule(item);
}
}
};
// Gets an item from the cache. If the key does not exist or if
// the item has expired, return null.
cache.get = function(key) {
// Get item from storage
var itm = store.getCacheItem(key);
if (itm) {
// Current timestamp
var now = new Date();
// If the item has sliding expiration, change the expires property
// and rebuild the schedule.
if (itm.slidingExpiration) {
itm.expires = addMilliseconds(now, (itm.slidingExpiration * 1000));
// Only rebuild the schedule if it expires earlier than nextCheck
if ((key == nextKey) || (nextCheck && itm.expires < nextCheck)) {
schedule();
}
else {
var b = true;
}
}
// If the item has expired, return null
if (itm.expires && itm.expires < now) {
return null;
}
return itm;
}
return null;
};
// Removes an item from the cache
cache.remove = function(key) {
if (key !== undefined && key !== null && key !== NaN && cache.count > 0) {
return removeItem(key, "removed");
// Rebuild the schedule if next check
// is based on this cache item.
if (nextKey == key) {
schedule();
}
}
};
// Removes all items from the cache
cache.clear = function() {
if (cache.count > 0) {
cache.count = 0;
store.clear();
if (currentTimeout !== null) {
clearTimeout(currentTimeout);
currentTimeout = null;
}
}
};
// Build the schedule if items exist in the cache
if (store.getCacheItems().length > 0) {
schedule();
}
}
// Represents a cache item.
function cacheItem(key, value, expires, slidingExpiration) {
this.key = key;
this.value = value;
this.expires = expires;
this.slidingExpiration = slidingExpiration;
}
// Represents a dependency mapper
function dependencyMapper(key, mappings) {
this.key = key;
this.mappings = mappings;
}
function storage(useLocalStorage) {
// The cache items
var _items = [];
// The cache keys
var _keys = [];
// The cache dependency mappings
var _dependencyMappings = [];
(function() {
if (useLocalStorage && window.localStorage) {
// Create an empty object in localStorage if undefined
if (!window.localStorage.jCacher) {
window.localStorage.jCacher = jQuery.toJSON({ items: [], dependencyMappings: [] });
}
// Else get the cache object from local storage
else {
var cacheItem = jQuery.parseJSON(window.localStorage.jCacher);
// Loop all items and make the expires property to a Date
for (var i = 0; i < cacheItem.items.length; i++) {
var item = cacheItem.items[i];
item.expires = new Date(item.expires);
_items.push(item);
}
_dependencyMappings = cacheItem.dependencyMappings;
}
for (var i = 0; i < _items.length; i++) {
_keys.push(_items[i].key);
}
}
})();
// Gets a cache item by key
this.getCacheItem = function(key) {
//var index = _keys.indexOf(key);
var index = $.inArray(key, _keys);
return index > -1 ? _items[index] : null;
};
// Gets all cache items
this.getCacheItems = function() {
return _items;
};
// Removes a cache item from storage
this.removeCacheItem = function(key) {
//var indexToRemove = _keys.indexOf(key);
var indexToRemove = $.inArray(key, _keys);
if (useLocalStorage && window.localStorage) {
// Get cache object from localStorage
var cacheItem = jQuery.parseJSON(window.localStorage.jCacher);
// Remove from local storage object
cacheItem.dependencyMappings.splice(indexToRemove, 1);
cacheItem.items.splice(indexToRemove, 1);
// Put the JSONized object to localStorage
window.localStorage.jCacher = jQuery.toJSON(cacheItem);
}
// Remove from local objects
_items.splice(indexToRemove, 1);
_keys.splice(indexToRemove, 1);
_dependencyMappings.splice(indexToRemove, 1);
};
// Adds a cache item to storage
this.addCacheItem = function(value) {
//var index = _keys.indexOf(value.key);
var index = $.inArray(value.key, _keys);
if (index == -1) {
var mapper = new dependencyMapper(value.key, []);
_items.push(value);
_keys.push(value.key);
_dependencyMappings.push(mapper);
if (useLocalStorage && window.localStorage) {
var cacheItem = jQuery.parseJSON(window.localStorage.jCacher);
var jsonValue = (function() {
var obj = new Object();
obj.expires = value.expires.getTime();
obj.key = value.key;
obj.value = value.value;
obj.slidingExpiration = value.slidingExpiration;
return obj;
})();
cacheItem.items.push(jsonValue);
cacheItem.dependencyMappings.push(mapper);
window.localStorage.jCacher = jQuery.toJSON(cacheItem);
}
}
else {
_items[index] = value;
if (useLocalStorage && window.localStorage) {
var cacheItem = jQuery.parseJSON(window.localStorage.jCacher);
cacheItem.items[index] = value;
window.localStorage.jCacher = jQuery.toJSON(cacheItem);
}
}
};
// Gets all cache keys
this.getCacheKeys = function() {
return _keys;
};
// Register dependencies to storage
this.registerDependencies = function(key, dependencies) {
for (var i = 0; i < dependencies.length; i++) {
//var mappingsIndex = _keys.indexOf(dependencies[i]);
var mappingsIndex = $.inArray(dependencies[i], _keys);
if (mappingsIndex != -1) {
//if (_dependencyMappings[mappingsIndex].mappings.indexOf(key) == -1) {
if ($.inArray(key, _dependencyMappings[mappingsIndex].mappings) == -1) {
_dependencyMappings[mappingsIndex].mappings.push(key);
if (useLocalStorage && window.localStorage) {
var cacheItem = jQuery.parseJSON(window.localStorage.jCacher);
cacheItem.dependencyMappings[mappingsIndex].mappings.push(key);
window.localStorage.jCacher = jQuery.toJSON(cacheItem);
}
}
}
}
};
// Gets dependency mappings for the specified cache key
this.getDependencyMappings = function(key) {
//var index = _keys.indexOf(key);
var index = $.inArray(key, _keys);
return index > -1 ? _dependencyMappings[index].mappings : null;
};
// Clears all items in the storage.
this.clear = function() {
if (window.localStorage) {
window.localStorage.removeItem("jCacher");
}
_items = [];
_dependencyMappings = [];
_keys = [];
};
};
})(jQuery);
// Knockout Mapping plugin v2.0.1
// (c) 2011 Steven Sanderson, Roy Jacobs - http://knockoutjs.com/
// License: Ms-Pl (http://www.opensource.org/licenses/ms-pl.html)
ko.exportSymbol=function(g,q){for(var k=g.split("."),i=window,e=0;e<k.length-1;e++)i=i[k[e]];i[k[k.length-1]]=q};ko.exportProperty=function(g,q,k){g[q]=k};
(function(){function g(a,c){for(var b in c)c.hasOwnProperty(b)&&c[b]&&(a[b]&&!(a[b]instanceof Array)?g(a[b],c[b]):a[b]=c[b])}function q(a,c){var b={};g(b,a);g(b,c);return b}function k(a){return a&&typeof a==="object"&&a.constructor==(new Date).constructor?"date":typeof a}function i(a,c){a=a||{};if(a.create instanceof Function||a.update instanceof Function||a.key instanceof Function||a.arrayChanged instanceof Function)a={"":a};if(c)a.ignore=e(c.ignore,a.ignore),a.include=e(c.include,a.include),a.copy=
e(c.copy,a.copy);a.ignore=e(a.ignore,j.ignore);a.include=e(a.include,j.include);a.copy=e(a.copy,j.copy);a.mappedProperties=a.mappedProperties||{};return a}function e(a,c){a instanceof Array||(a=k(a)==="undefined"?[]:[a]);c instanceof Array||(c=k(c)==="undefined"?[]:[c]);return a.concat(c)}function J(a,c){var b=ko.dependentObservable;ko.dependentObservable=function(b,c,d){var d=d||{},k=d.deferEvaluation;b&&typeof b=="object"&&(d=b);var t=!1,e=function(b){var c=n({read:function(){t||(ko.utils.arrayRemoveItem(a,
b),t=!0);return b.apply(b,arguments)},write:function(a){return b(a)},deferEvaluation:!0});c.__ko_proto__=n;return c};d.deferEvaluation=!0;b=new n(b,c,d);b.__ko_proto__=n;k||(a.push(b),b=e(b));return b};var d=c();ko.dependentObservable=b;return d}function z(a,c,b,d,f,e){var y=ko.utils.unwrapObservable(c)instanceof Array,e=e||"";if(ko.mapping.isMapped(a))var r=ko.utils.unwrapObservable(a)[m],b=q(r,b);var t=function(){return b[d]&&b[d].create instanceof Function},j=function(a){return J(C,function(){return b[d].create({data:a||
c,parent:f})})},g=function(){return b[d]&&b[d].update instanceof Function},o=function(a,K){var e={data:K||c,parent:f,target:ko.utils.unwrapObservable(a)};if(ko.isWriteableObservable(a))e.observable=a;return b[d].update(e)};if(A.get(c))return a;d=d||"";if(y){var y=[],r=!1,h=function(a){return a};if(b[d]&&b[d].key)h=b[d].key,r=!0;if(!ko.isObservable(a))a=ko.observableArray([]),a.mappedRemove=function(b){var c=typeof b=="function"?b:function(a){return a===h(b)};return a.remove(function(a){return c(h(a))})},
a.mappedRemoveAll=function(b){var c=w(b,h);return a.remove(function(a){return ko.utils.arrayIndexOf(c,h(a))!=-1})},a.mappedDestroy=function(b){var c=typeof b=="function"?b:function(a){return a===h(b)};return a.destroy(function(a){return c(h(a))})},a.mappedDestroyAll=function(b){var c=w(b,h);return a.destroy(function(a){return ko.utils.arrayIndexOf(c,h(a))!=-1})},a.mappedIndexOf=function(b){var c=w(a(),h),b=h(b);return ko.utils.arrayIndexOf(c,b)},a.mappedCreate=function(b){if(a.mappedIndexOf(b)!==
-1)throw Error("There already is an object with the key that you specified.");var c=t()?j(b):b;g()&&(b=o(c,b),ko.isWriteableObservable(c)?c(b):c=b);a.push(c);return c};var l=w(ko.utils.unwrapObservable(a),h).sort(),i=w(c,h);r&&i.sort();for(var r=ko.utils.compareArrays(l,i),l={},i=[],n=0,v=r.length;n<v;n++){var u=r[n],s,p=e+"["+n+"]";switch(u.status){case "added":var x=B(ko.utils.unwrapObservable(c),u.value,h);s=ko.utils.unwrapObservable(z(void 0,x,b,d,a,p));p=F(ko.utils.unwrapObservable(c),x,l);i[p]=
s;l[p]=!0;break;case "retained":x=B(ko.utils.unwrapObservable(c),u.value,h);s=B(a,u.value,h);z(s,x,b,d,a,p);p=F(ko.utils.unwrapObservable(c),x,l);i[p]=s;l[p]=!0;break;case "deleted":s=B(a,u.value,h)}y.push({event:u.status,item:s})}a(i);b[d]&&b[d].arrayChanged&&ko.utils.arrayForEach(y,function(a){b[d].arrayChanged(a.event,a.item)})}else if(D(c)){a=ko.utils.unwrapObservable(a);if(!a)if(t())return l=j(),g()&&(l=o(l)),l;else{if(g())return o(l);a={}}g()&&(a=o(a));A.save(c,a);G(c,function(d){var f=e.length?
e+"."+d:d;if(ko.utils.arrayIndexOf(b.ignore,f)==-1)if(ko.utils.arrayIndexOf(b.copy,f)!=-1)a[d]=c[d];else{var h=A.get(c[d])||z(a[d],c[d],b,d,a,f);if(ko.isWriteableObservable(a[d]))a[d](ko.utils.unwrapObservable(h));else a[d]=h;b.mappedProperties[f]=!0}})}else switch(k(c)){case "function":g()?ko.isWriteableObservable(c)?(c(o(c)),a=c):a=o(c):a=c;break;default:ko.isWriteableObservable(a)?g()?a(o(a)):a(ko.utils.unwrapObservable(c)):(a=t()?j():ko.observable(ko.utils.unwrapObservable(c)),g()&&a(o(a)))}return a}
function F(a,c,b){for(var d=0,f=a.length;d<f;d++)if(b[d]!==!0&&a[d]===c)return d;return null}function H(a,c){var b;c&&(b=c(a));k(b)==="undefined"&&(b=a);return ko.utils.unwrapObservable(b)}function B(a,c,b){a=ko.utils.arrayFilter(ko.utils.unwrapObservable(a),function(a){return H(a,b)===c});if(a.length==0)throw Error("When calling ko.update*, the key '"+c+"' was not found!");if(a.length>1&&D(a[0]))throw Error("When calling ko.update*, the key '"+c+"' was not unique!");return a[0]}function w(a,c){return ko.utils.arrayMap(ko.utils.unwrapObservable(a),
function(a){return c?H(a,c):a})}function G(a,c){if(a instanceof Array)for(var b=0;b<a.length;b++)c(b);else for(b in a)c(b)}function D(a){var c=k(a);return c==="object"&&a!==null&&c!=="undefined"}function I(){var a=[],c=[];this.save=function(b,d){var f=ko.utils.arrayIndexOf(a,b);f>=0?c[f]=d:(a.push(b),c.push(d))};this.get=function(b){b=ko.utils.arrayIndexOf(a,b);return b>=0?c[b]:void 0}}ko.mapping={};var m="__ko_mapping__",n=ko.dependentObservable,E=0,C,A,v={include:["_destroy"],ignore:[],copy:[]},
j=v;ko.mapping.isMapped=function(a){return(a=ko.utils.unwrapObservable(a))&&a[m]};ko.mapping.fromJS=function(a){if(arguments.length==0)throw Error("When calling ko.fromJS, pass the object you want to convert.");window.setTimeout(function(){E=0},0);E++||(C=[],A=new I);var c,b;arguments.length==2&&(arguments[1][m]?b=arguments[1]:c=arguments[1]);arguments.length==3&&(c=arguments[1],b=arguments[2]);b&&(c=q(c,b[m]));c=i(c);var d=z(b,a,c);b&&(d=b);--E||window.setTimeout(function(){ko.utils.arrayForEach(C,
function(a){a&&a()})},0);d[m]=q(d[m],c);return d};ko.mapping.fromJSON=function(a){var c=ko.utils.parseJson(a);arguments[0]=c;return ko.mapping.fromJS.apply(this,arguments)};ko.mapping.updateFromJS=function(){throw Error("ko.mapping.updateFromJS, use ko.mapping.fromJS instead. Please note that the order of parameters is different!");};ko.mapping.updateFromJSON=function(){throw Error("ko.mapping.updateFromJSON, use ko.mapping.fromJSON instead. Please note that the order of parameters is different!");
};ko.mapping.toJS=function(a,c){j||ko.mapping.resetDefaultOptions();if(arguments.length==0)throw Error("When calling ko.mapping.toJS, pass the object you want to convert.");if(!(j.ignore instanceof Array))throw Error("ko.mapping.defaultOptions().ignore should be an array.");if(!(j.include instanceof Array))throw Error("ko.mapping.defaultOptions().include should be an array.");if(!(j.copy instanceof Array))throw Error("ko.mapping.defaultOptions().copy should be an array.");c=i(c,a[m]);return ko.mapping.visitModel(a,
function(a){return ko.utils.unwrapObservable(a)},c)};ko.mapping.toJSON=function(a,c){var b=ko.mapping.toJS(a,c);return ko.utils.stringifyJson(b)};ko.mapping.defaultOptions=function(){if(arguments.length>0)j=arguments[0];else return j};ko.mapping.resetDefaultOptions=function(){j={include:v.include.slice(0),ignore:v.ignore.slice(0),copy:v.copy.slice(0)}};ko.mapping.visitModel=function(a,c,b){b=b||{};b.visitedObjects=b.visitedObjects||new I;b.parentName||(b=i(b));var d,f=ko.utils.unwrapObservable(a);
if(D(f))c(a,b.parentName),d=f instanceof Array?[]:{};else return c(a,b.parentName);b.visitedObjects.save(a,d);var e=b.parentName;G(f,function(a){if(!(b.ignore&&ko.utils.arrayIndexOf(b.ignore,a)!=-1)){var g=f[a],i=b,j=e||"";f instanceof Array?e&&(j+="["+a+"]"):(e&&(j+="."),j+=a);i.parentName=j;if(!(ko.utils.arrayIndexOf(b.copy,a)===-1&&ko.utils.arrayIndexOf(b.include,a)===-1&&f[m]&&f[m].mappedProperties&&!f[m].mappedProperties[a]&&!(f instanceof Array)))switch(k(ko.utils.unwrapObservable(g))){case "object":case "undefined":i=
b.visitedObjects.get(g);d[a]=k(i)!=="undefined"?i:ko.mapping.visitModel(g,c,b);break;default:d[a]=c(g,b.parentName)}}});return d};ko.exportSymbol("ko.mapping",ko.mapping);ko.exportSymbol("ko.mapping.fromJS",ko.mapping.fromJS);ko.exportSymbol("ko.mapping.fromJSON",ko.mapping.fromJSON);ko.exportSymbol("ko.mapping.isMapped",ko.mapping.isMapped);ko.exportSymbol("ko.mapping.defaultOptions",ko.mapping.defaultOptions);ko.exportSymbol("ko.mapping.toJS",ko.mapping.toJS);ko.exportSymbol("ko.mapping.toJSON",
ko.mapping.toJSON);ko.exportSymbol("ko.mapping.updateFromJS",ko.mapping.updateFromJS);ko.exportSymbol("ko.mapping.updateFromJSON",ko.mapping.updateFromJSON);ko.exportSymbol("ko.mapping.visitModel",ko.mapping.visitModel)})();
// Copyright (c) Microsoft Corporation.  All rights reserved.
// This code is licensed by Microsoft Corporation under the terms
// of the MICROSOFT REACTIVE EXTENSIONS FOR JAVASCRIPT AND .NET LIBRARIES License.
// See http://go.microsoft.com/fwlink/?LinkId=186234.
(function(){var a;var b;var c=this;var d="Index out of range";if(typeof ProvideCustomRxRootObject =="undefined")b=c.Rx={}; else b=ProvideCustomRxRootObject();var e=function(){};var f=function(){return new Date().getTime();};var g=function(r0,s0){return r0===s0;};var h=function(r0){return r0;};var i=function(r0){return {Dispose:r0};};var j={Dispose:e};b.Disposable={Create:i,Empty:j};var k=b.BooleanDisposable=function(){var r0=false;this.GetIsDisposed=function(){return r0;};this.Dispose=function(){r0=true;};};var l=function(r0){var s0=false;r0.a++;this.Dispose=function(){var t0=false;if(!r0.b){if(!this.c){this.c=true;r0.a--;if(r0.a==0&&r0.d){r0.b=true;t0=true;}}}if(t0)r0.e.Dispose();};};var m=b.RefCountDisposable=function(r0){this.d=false;this.b=false;this.e=r0;this.a=0;this.Dispose=function(){var s0=false;if(!this.b){if(!this.d){this.d=true;if(this.a==0){this.b=true;s0=true;}}}if(s0)this.e.Dispose();};this.GetDisposable=function(){if(this.b)return j; else return new l(this);};};var n=b.CompositeDisposable=function(){var r0=new q();for(var s0=0;s0<arguments.length;s0++) r0.Add(arguments[s0]);var t0=false;this.GetCount=function(){return r0.GetCount();};this.Add=function(u0){if(!t0)r0.Add(u0); else u0.Dispose();};this.Remove=function(u0,v0){if(!t0){var w0=r0.Remove(u0);if(!v0&w0)u0.Dispose();}};this.Dispose=function(){if(!t0){t0=true;this.Clear();}};this.Clear=function(){for(var u0=0;u0<r0.GetCount();u0++) r0.GetItem(u0).Dispose();r0.Clear();};};var o=b.MutableDisposable=function(){var r0=false;var s0;this.Get=function(){return s0;},this.Replace=function(t0){if(r0&&t0!==a)t0.Dispose(); else{if(s0!==a)s0.Dispose();s0=t0;}};this.Dispose=function(){if(!r0){r0=true;if(s0!==a)s0.Dispose();}};};var p=function(r0){var s0=[];for(var t0=0;t0<r0.length;t0++) s0.push(r0[t0]);return s0;};var q=b.List=function(r0){var s0=[];var t0=0;var u0=r0!==a?r0:g;this.Add=function(v0){s0[t0]=v0;t0++;};this.RemoveAt=function(v0){if(v0<0||v0>=t0)throw d;if(v0==0){s0.shift();t0--;}else{s0.splice(v0,1);t0--;}};this.IndexOf=function(v0){for(var w0=0;w0<t0;w0++){if(u0(v0,s0[w0]))return w0;}return -1;};this.Remove=function(v0){var w0=this.IndexOf(v0);if(w0==-1)return false;this.RemoveAt(w0);return true;};this.Clear=function(){s0=[];t0=0;};this.GetCount=function(){return t0;};this.GetItem=function(v0){if(v0<0||v0>=t0)throw d;return s0[v0];};this.SetItem=function(v0,w0){if(v0<0||v0>=t0)throw d;s0[v0]=w0;};this.ToArray=function(){var v0=[];for(var w0=0;w0<this.GetCount();w0++) v0.push(this.GetItem(w0));return v0;};};var r=function(r0){if(r0===null)r0=g;this.f=r0;var s0=4;this.g=new Array(s0);this.h=0;};r.prototype.i=function(r0,s0){return this.f(this.g[r0],this.g[s0])<0;};r.prototype.j=function(r0){if(r0>=this.h||r0<0)return;var s0=r0-1>>1;if(s0<0||s0==r0)return;if(this.i(r0,s0)){var t0=this.g[r0];this.g[r0]=this.g[s0];this.g[s0]=t0;this.j(s0);}};r.prototype.k=function(r0){if(r0===a)r0=0;var s0=2*r0+1;var t0=2*r0+2;var u0=r0;if(s0<this.h&&this.i(s0,u0))u0=s0;if(t0<this.h&&this.i(t0,u0))u0=t0;if(u0!=r0){var v0=this.g[r0];this.g[r0]=this.g[u0];this.g[u0]=v0;this.k(u0);}};r.prototype.GetCount=function(){return this.h;};r.prototype.Peek=function(){if(this.h==0)throw "Heap is empty.";return this.g[0];};r.prototype.Dequeue=function(){var r0=this.Peek();this.g[0]=this.g[--this.h];delete this.g[this.h];this.k();return r0;};r.prototype.Enqueue=function(r0){var s0=this.h++;this.g[s0]=r0;this.j(s0);};var s=b.Scheduler=function(r0,s0,t0){this.Schedule=r0;this.ScheduleWithTime=s0;this.Now=t0;this.ScheduleRecursive=function(u0){var v0=this;var w0=new n();var x0;x0=function(){u0(function(){var y0=false;var z0=false;var A0;A0=v0.Schedule(function(){x0();if(y0)w0.Remove(A0); else z0=true;});if(!z0){w0.Add(A0);y0=true;}});};w0.Add(v0.Schedule(x0));return w0;};this.ScheduleRecursiveWithTime=function(u0,v0){var w0=this;var x0=new n();var y0;y0=function(){u0(function(z0){var A0=false;var B0=false;var C0;C0=w0.ScheduleWithTime(function(){y0();if(A0)x0.Remove(C0); else B0=true;},z0);if(!B0){x0.Add(C0);A0=true;}});};x0.Add(w0.ScheduleWithTime(y0,v0));return x0;};};var t=b.VirtualScheduler=function(r0,s0,t0,u0){var v0=new s(function(w0){return this.ScheduleWithTime(w0,0);},function(w0,x0){return this.ScheduleVirtual(w0,u0(x0));},function(){return t0(this.l);});v0.ScheduleVirtual=function(w0,x0){var y0=new k();var z0=s0(this.l,x0);var A0=function(){if(!y0.IsDisposed)w0();};var B0=new y(A0,z0);this.m.Enqueue(B0);return y0;};v0.Run=function(){while(this.m.GetCount()>0){var w0=this.m.Dequeue();this.l=w0.n;w0.o();}};v0.RunTo=function(w0){while(this.m.GetCount()>0&&this.f(this.m.Peek().n,w0)<=0){var x0=this.m.Dequeue();this.l=x0.n;x0.o();}};v0.GetTicks=function(){return this.l;};v0.l=0;v0.m=new r(function(w0,x0){return r0(w0.n,x0.n);});v0.f=r0;return v0;};var u=b.TestScheduler=function(){var r0=new t(function(s0,t0){return s0-t0;},function(s0,t0){return s0+t0;},function(s0){return new Date(s0);},function(s0){if(s0<=0)return 1;return s0;});return r0;};var v=new s(function(r0){return this.ScheduleWithTime(r0,0);},function(r0,s0){var t0=this.Now()+s0;var u0=new y(r0,t0);if(this.m===a){var v0=new w();try{this.m.Enqueue(u0);v0.p();}finally{v0.q();}}else this.m.Enqueue(u0);return u0.r();},f);v.s=function(r0){if(this.m===a){var s0=new w();try{r0();s0.p();}finally{s0.q();}}else r0();};s.CurrentThread=v;var w=function(){v.m=new r(function(r0,s0){try{return r0.n-s0.n;}catch(t0){debugger;}});this.q=function(){v.m=a;};this.p=function(){while(v.m.GetCount()>0){var r0=v.m.Dequeue();if(!r0.t()){while(r0.n-v.Now()>0);if(!r0.t())r0.o();}}};};var x=0;var y=function(r0,s0){this.u=x++;this.o=r0;this.n=s0;this.v=new k();this.t=function(){return this.v.GetIsDisposed();};this.r=function(){return this.v;};};var z=new s(function(r0){r0();return j;},function(r0,s0){while(this.Now<s0);r0();},f);s.Immediate=z;var A=new s(function(r0){var s0=c.setTimeout(r0,0);return i(function(){c.clearTimeout(s0);});},function(r0,s0){var t0=c.setTimeout(r0,s0);return i(function(){c.clearTimeout(t0);});},f);s.Timeout=A;var B=b.Observer=function(r0,s0,t0){this.OnNext=r0===a?e:r0;this.OnError=s0===a?function(u0){throw u0;}:s0;this.OnCompleted=t0===a?e:t0;this.AsObserver=function(){var u0=this;return new B(function(v0){u0.OnNext(v0);},function(v0){u0.OnError(v0);},function(){u0.OnCompleted();});};};var C=B.Create=function(r0,s0,t0){return new B(r0,s0,t0);};var D=b.Observable=function(r0){this.w=r0;};var E=D.CreateWithDisposable=function(r0){return new D(r0);};var F=D.Create=function(r0){return E(function(s0){return i(r0(s0));});};var G=function(){return this.Select(function(r0){return r0.Value;});};D.prototype={Subscribe:function(r0,s0,t0){var u0;if(arguments.length==0||arguments.length>1||typeof r0 =="function")u0=new B(r0,s0,t0); else u0=r0;return this.x(u0);},x:function(r0){var s0=false;var t0=new o();var u0=this;v.s(function(){var v0=new B(function(w0){if(!s0)r0.OnNext(w0);},function(w0){if(!s0){s0=true;t0.Dispose();r0.OnError(w0);}},function(){if(!s0){s0=true;t0.Dispose();r0.OnCompleted();}});t0.Replace(u0.w(v0));});return new n(t0,i(function(){s0=true;}));},Select:function(r0){var s0=this;return E(function(t0){var u0=0;return s0.Subscribe(new B(function(v0){var w0;try{w0=r0(v0,u0++);}catch(x0){t0.OnError(x0);return;}t0.OnNext(w0);},function(v0){t0.OnError(v0);},function(){t0.OnCompleted();}));});},Let:function(r0,s0){if(s0===a)return r0(this);var t0=this;return E(function(u0){var v0=s0();var w0;try{w0=r0(v0);}catch(A0){return L(A0).Subscribe(u0);}var x0=new o();var y0=new o();var z0=new n(y0,x0);x0.Replace(w0.Subscribe(function(A0){u0.OnNext(A0);},function(A0){u0.OnError(A0);z0.Dispose();},function(){u0.OnCompleted();z0.Dispose();}));y0.Replace(t0.Subscribe(v0));return z0;});},MergeObservable:function(){var r0=this;return E(function(s0){var t0=false;var u0=new n();var v0=new o();u0.Add(v0);v0.Replace(r0.Subscribe(function(w0){var x0=new o();u0.Add(x0);x0.Replace(w0.Subscribe(function(y0){s0.OnNext(y0);},function(y0){s0.OnError(y0);},function(){u0.Remove(x0);if(u0.GetCount()==1&&t0)s0.OnCompleted();}));},function(w0){s0.OnError(w0);},function(){t0=true;if(u0.GetCount()==1)s0.OnCompleted();}));return u0;});},y:function(r0,s0){var t0=p(s0);t0.unshift(this);return r0(t0);},Concat:function(){return this.y(I,arguments);},Merge:function(){return this.y(H,arguments);},Catch:function(){return this.y(P,arguments);},OnErrorResumeNext:function(){return this.y(V,arguments);},Zip:function(r0,s0){var t0=this;return E(function(u0){var v0=false;var w0=[];var x0=[];var y0=false;var z0=false;var A0=new n();var B0=function(C0){A0.Dispose();w0=a;x0=a;u0.OnError(C0);};A0.Add(t0.Subscribe(function(C0){if(z0){u0.OnCompleted();return;}if(x0.length>0){var D0=x0.shift();var E0;try{E0=s0(C0,D0);}catch(F0){A0.Dispose();u0.OnError(F0);return;}u0.OnNext(E0);}else w0.push(C0);},B0,function(){if(z0){u0.OnCompleted();return;}y0=true;}));A0.Add(r0.Subscribe(function(C0){if(y0){u0.OnCompleted();return;}if(w0.length>0){var D0=w0.shift();var E0;try{E0=s0(D0,C0);}catch(F0){A0.Dispose();u0.OnError(F0);return;}u0.OnNext(E0);}else x0.push(C0);},B0,function(){if(y0){u0.OnCompleted();return;}z0=true;}));return A0;});},CombineLatest:function(r0,s0){var t0=this;return E(function(u0){var v0=false;var w0=false;var x0=false;var y0;var z0;var A0=false;var B0=false;var C0=new n();var D0=function(E0){C0.Dispose();u0.OnError(E0);};C0.Add(t0.Subscribe(function(E0){if(B0){u0.OnCompleted();return;}if(x0){var F0;try{F0=s0(E0,z0);}catch(G0){C0.Dispose();u0.OnError(G0);return;}u0.OnNext(F0);}y0=E0;w0=true;},D0,function(){if(B0){u0.OnCompleted();return;}A0=true;}));C0.Add(r0.Subscribe(function(E0){if(A0){u0.OnCompleted();return;}if(w0){var F0;try{F0=s0(y0,E0);}catch(G0){C0.Dispose();u0.OnError(G0);return;}u0.OnNext(F0);}z0=E0;x0=true;},D0,function(){if(A0){u0.OnCompleted();return;}B0=true;}));});},Switch:function(){var r0=this;return E(function(s0){var t0=false;var u0=new o();var v0=new o();v0.Replace(r0.Subscribe(function(w0){if(!t0){var x0=new o();x0.Replace(w0.Subscribe(function(y0){s0.OnNext(y0);},function(y0){v0.Dispose();u0.Dispose();s0.OnError(y0);},function(){u0.Replace(a);if(t0)s0.OnCompleted();}));u0.Replace(x0);}},function(w0){u0.Dispose();s0.OnError(w0);},function(){t0=true;if(u0.Get()===a)s0.OnCompleted();}));return new n(v0,u0);});},TakeUntil:function(r0){var s0=this;return E(function(t0){var u0=new n();u0.Add(r0.Subscribe(function(){t0.OnCompleted();u0.Dispose();},function(v0){t0.OnError(v0);},function(){}));u0.Add(s0.Subscribe(t0));return u0;});},SkipUntil:function(r0){var s0=this;return E(function(t0){var u0=true;var v0=new n();v0.Add(r0.Subscribe(function(){u0=false;},function(w0){t0.OnError(w0);},e));v0.Add(s0.Subscribe(new B(function(w0){if(!u0)t0.OnNext(w0);},function(w0){t0.OnError(w0);},function(){if(!u0)t0.OnCompleted();})));return v0;});},Scan1:function(r0){var s0=this;return O(function(){var t0;var u0=false;return s0.Select(function(v0){if(u0)t0=r0(t0,v0); else{t0=v0;u0=true;}return t0;});});},Scan:function(r0,s0){var t0=this;return O(function(){var u0;var v0=false;return t0.Select(function(w0){if(v0)u0=s0(u0,w0); else{u0=s0(r0,w0);v0=true;}return u0;});});},Scan0:function(r0,s0){var t0=this;return E(function(u0){var v0=r0;var w0=true;return t0.Subscribe(function(x0){if(w0){w0=false;u0.OnNext(v0);}try{v0=s0(v0,x0);}catch(y0){u0.OnError(y0);return;}u0.OnNext(v0);},function(x0){if(w0)u0.OnNext(v0);u0.OnError(x0);},function(){if(w0)u0.OnNext(v0);u0.OnCompleted();});});},Finally:function(r0){var s0=this;return F(function(t0){var u0=s0.Subscribe(t0);return function(){try{u0.Dispose();r0();}catch(v0){r0();throw v0;}};});},Do:function(r0,s0,t0){var u0;if(arguments.length==0||arguments.length>1||typeof r0 =="function")u0=new B(r0,s0!==a?s0:e,t0); else u0=r0;var v0=this;return E(function(w0){return v0.Subscribe(new B(function(x0){try{u0.OnNext(x0);}catch(y0){w0.OnError(y0);return;}w0.OnNext(x0);},function(x0){if(s0!==a)try{u0.OnError(x0);}catch(y0){w0.OnError(y0);return;}w0.OnError(x0);},function(){if(t0!==a)try{u0.OnCompleted();}catch(x0){w0.OnError(x0);return;}w0.OnCompleted();}));});},Where:function(r0){var s0=this;return E(function(t0){var u0=0;return s0.Subscribe(new B(function(v0){var w0=false;try{w0=r0(v0,u0++);}catch(x0){t0.OnError(x0);return;}if(w0)t0.OnNext(v0);},function(v0){t0.OnError(v0);},function(){t0.OnCompleted();}));});},Take:function(r0,s0){if(s0===a)s0=z;var t0=this;return E(function(u0){if(r0<=0){t0.Subscribe().Dispose();return N(s0).Subscribe(u0);}var v0=r0;return t0.Subscribe(new B(function(w0){if(v0-->0){u0.OnNext(w0);if(v0==0)u0.OnCompleted();}},function(w0){u0.OnError(w0);},function(){u0.OnCompleted();}));});},GroupBy:function(r0,s0,t0){if(r0===a)r0=h;if(s0===a)s0=h;if(t0===a)t0=function(v0){return v0.toString();};var u0=this;return E(function(v0){var w0={};var x0=new o();var y0=new m(x0);x0.Replace(u0.Subscribe(function(z0){var A0;try{A0=r0(z0);}catch(G0){for(var H0 in w0) w0[H0].OnError(G0);v0.OnError(G0);return;}var B0=false;var C0;try{var D0=t0(A0);if(w0[D0]===a){C0=new i0();w0[D0]=C0;B0=true;}else C0=w0[D0];}catch(G0){for(var H0 in w0) w0[H0].OnError(G0);v0.OnError(G0);return;}if(B0){var E0=E(function(G0){return new n(y0.GetDisposable(),C0.Subscribe(G0));});E0.Key=A0;v0.OnNext(E0);}var F0;try{F0=s0(z0);}catch(G0){for(var H0 in w0) w0[H0].OnError(G0);v0.OnError(G0);return;}C0.OnNext(F0);},function(z0){for(var A0 in w0) w0[A0].OnError(z0);v0.OnError(z0);},function(){for(var z0 in w0) w0[z0].OnCompleted();v0.OnCompleted();}));return y0;});},TakeWhile:function(r0){var s0=this;return E(function(t0){var u0=true;return s0.Subscribe(new B(function(v0){if(u0){try{u0=r0(v0);}catch(w0){t0.OnError(w0);return;}if(u0)t0.OnNext(v0); else t0.OnCompleted();}},function(v0){t0.OnError(v0);},function(){t0.OnCompleted();}));});},SkipWhile:function(r0){var s0=this;return E(function(t0){var u0=false;return s0.Subscribe(new B(function(v0){if(!u0)try{u0=!r0(v0);}catch(w0){t0.OnError(w0);return;}if(u0)t0.OnNext(v0);},function(v0){t0.OnError(v0);},function(){t0.OnCompleted();}));});},Skip:function(r0){var s0=this;return E(function(t0){var u0=r0;return s0.Subscribe(new B(function(v0){if(u0--<=0)t0.OnNext(v0);},function(v0){t0.OnError(v0);},function(){t0.OnCompleted();}));});},SelectMany:function(r0){return this.Select(r0).MergeObservable();},TimeInterval:function(r0){if(r0===a)r0=z;var s0=this;return O(function(){var t0=r0.Now();return s0.Select(function(u0){var v0=r0.Now();var w0=v0-t0;t0=v0;return {Interval:w0,Value:u0};});});},RemoveInterval:G,Timestamp:function(r0){if(r0===a)r0=z;return this.Select(function(s0){return {Timestamp:r0.Now(),Value:s0};});},RemoveTimestamp:G,Materialize:function(){var r0=this;return E(function(s0){return r0.Subscribe(new B(function(t0){s0.OnNext(new h0("N",t0));},function(t0){s0.OnNext(new h0("E",t0));s0.OnCompleted();},function(){s0.OnNext(new h0("C"));s0.OnCompleted();}));});},Dematerialize:function(){return this.SelectMany(function(r0){return r0;});},AsObservable:function(){var r0=this;return E(function(s0){return r0.Subscribe(s0);});},Delay:function(r0,s0){if(s0===a)s0=A;var t0=this;return E(function(u0){var v0=[];var w0=false;var x0=new o();var y0=t0.Materialize().Timestamp().Subscribe(function(z0){if(z0.Value.Kind=="E"){u0.OnError(z0.Value.Value);v0=[];if(w0)x0.Dispose();return;}v0.push({Timestamp:s0.Now()+r0,Value:z0.Value});if(!w0){x0.Replace(s0.ScheduleRecursiveWithTime(function(A0){var B0;do{B0=a;if(v0.length>0&&v0[0].Timestamp<=s0.Now())B0=v0.shift().Value;if(B0!==a)B0.Accept(u0);}while(B0!==a);if(v0.length>0){A0(Math.max(0,v0[0].Timestamp-s0.Now()));w0=true;}else w0=false;},r0));w0=true;}});return new n(y0,x0);});},Throttle:function(r0,s0){if(s0===a)s0=A;var t0=this;return E(function(u0){var v0;var w0=false;var x0=new o();var y0=0;var z0=t0.Subscribe(function(A0){w0=true;v0=A0;y0++;var B0=y0;x0.Replace(s0.ScheduleWithTime(function(){if(w0&&y0==B0)u0.OnNext(v0);w0=false;},r0));},function(A0){x0.Dispose();u0.OnError(A0);w0=false;y0++;},function(){x0.Dispose();if(w0)u0.OnNext(v0);u0.OnCompleted();w0=false;y0++;});return new n(z0,x0);});},Timeout:function(r0,s0,t0){if(t0===a)t0=A;if(s0===a)s0=L("Timeout",t0);var u0=this;return E(function(v0){var w0=new o();var x0=new o();var y0=0;var z0=y0;var A0=false;x0.Replace(t0.ScheduleWithTime(function(){A0=y0==z0;if(A0)w0.Replace(s0.Subscribe(v0));},r0));w0.Replace(u0.Subscribe(function(B0){var C0=0;if(!A0){y0++;C0=y0;v0.OnNext(B0);x0.Replace(t0.ScheduleWithTime(function(){A0=y0==C0;if(A0)w0.Replace(s0.Subscribe(v0));},r0));}},function(B0){if(!A0){y0++;v0.OnError(B0);}},function(){if(!A0){y0++;v0.OnCompleted();}}));return new n(w0,x0);});},Sample:function(r0,s0){if(s0===a)s0=A;var t0=this;return E(function(u0){var v0=false;var w0;var x0=false;var y0=new n();y0.Add(Y(r0,s0).Subscribe(function(z0){if(v0){u0.OnNext(w0);v0=false;}if(x0)u0.OnCompleted();},function(z0){u0.OnError(z0);},function(){u0.OnCompleted();}));y0.Add(t0.Subscribe(function(z0){v0=true;w0=z0;},function(z0){u0.OnError(z0);y0.Dispose();},function(){x0=true;}));return y0;});},Repeat:function(r0,s0){var t0=this;if(s0===a)s0=z;if(r0===a)r0=-1;return E(function(u0){var v0=r0;var w0=new o();var x0=new n(w0);var y0=function(z0){w0.Replace(t0.Subscribe(function(A0){u0.OnNext(A0);},function(A0){u0.OnError(A0);},function(){if(v0>0){v0--;if(v0==0){u0.OnCompleted();return;}}z0();}));};x0.Add(s0.ScheduleRecursive(y0));return x0;});},Retry:function(r0,s0){var t0=this;if(s0===a)s0=z;if(r0===a)r0=-1;return E(function(u0){var v0=r0;var w0=new o();var x0=new n(w0);var y0=function(z0){w0.Replace(t0.Subscribe(function(A0){u0.OnNext(A0);},function(A0){if(v0>0){v0--;if(v0==0){u0.OnError(A0);return;}}z0();},function(){u0.OnCompleted();}));};x0.Add(s0.ScheduleRecursive(y0));return x0;});},BufferWithTime:function(r0,s0,t0){if(t0===a)t0=A;if(s0===a)s0=r0;var u0=this;return E(function(v0){var w0=new q();var x0=t0.Now();var y0=function(){var C0=[];for(var D0=0;D0<w0.GetCount();D0++){var E0=w0.GetItem(D0);if(E0.Timestamp-x0>=0)C0.push(E0.Value);}return C0;};var z0=new n();var A0=function(C0){v0.OnError(C0);};var B0=function(){v0.OnNext(y0());v0.OnCompleted();};z0.Add(u0.Subscribe(function(C0){w0.Add({Value:C0,Timestamp:t0.Now()});},A0,B0));z0.Add(a0(r0,s0,t0).Subscribe(function(C0){var D0=y0();var E0=t0.Now()+s0-r0;while(w0.GetCount()>0&&w0.GetItem(0).Timestamp-E0<=0)w0.RemoveAt(0);v0.OnNext(D0);x0=E0;},A0,B0));return z0;});},BufferWithTimeOrCount:function(r0,s0,t0){if(t0===a)t0=A;var u0=this;return E(function(v0){var w0=0;var x0=new q();var y0=function(){v0.OnNext(x0.ToArray());x0.Clear();w0++;};var z0=new o();var A0;A0=function(C0){var D0=t0.ScheduleWithTime(function(){var E0=false;var F0=0;if(C0==w0){y0();F0=w0;E0=true;}if(E0)A0(F0);},r0);z0.Replace(D0);};A0(w0);var B0=u0.Subscribe(function(C0){var D0=false;var E0=0;x0.Add(C0);if(x0.GetCount()==s0){y0();E0=w0;D0=true;}if(D0)A0(E0);},function(C0){v0.OnError(C0);x0.Clear();},function(){v0.OnNext(x0.ToArray());w0++;v0.OnCompleted();x0.Clear();});return new n(B0,z0);});},BufferWithCount:function(r0,s0){if(s0===a)s0=r0;var t0=this;return E(function(u0){var v0=[];var w0=0;return t0.Subscribe(function(x0){if(w0==0)v0.push(x0); else w0--;var y0=v0.length;if(y0==r0){var z0=v0;v0=[];var A0=Math.min(s0,y0);for(var B0=A0;B0<y0;B0++) v0.push(z0[B0]);w0=Math.max(0,s0-r0);u0.OnNext(z0);}},function(x0){u0.OnError(x0);},function(){if(v0.length>0)u0.OnNext(v0);u0.OnCompleted();});});},StartWith:function(r0,s0){if(!(r0 instanceof Array))r0=[r0];if(s0===a)s0=z;var t0=this;return E(function(u0){var v0=new n();var w0=0;v0.Add(s0.ScheduleRecursive(function(x0){if(w0<r0.length){u0.OnNext(r0[w0]);w0++;x0();}else v0.Add(t0.Subscribe(u0));}));return v0;});},DistinctUntilChanged:function(r0,s0){if(r0===a)r0=h;if(s0===a)s0=g;var t0=this;return E(function(u0){var v0;var w0=false;return t0.Subscribe(function(x0){var y0;try{y0=r0(x0);}catch(A0){u0.OnError(A0);return;}var z0=false;if(w0)try{z0=s0(v0,y0);}catch(A0){u0.OnError(A0);return;}if(!w0||!z0){w0=true;v0=y0;u0.OnNext(x0);}},function(x0){u0.OnError(x0);},function(){u0.OnCompleted();});});},Publish:function(r0){if(r0===a)return new q0(this,new i0());var s0=this;return E(function(t0){var u0=new q0(s0,new i0());return new n(r0(u0).Subscribe(B),u0.Connect());});},Prune:function(r0,s0){if(s0===a)s0=z;if(r0===a)return new q0(this,new k0(s0));var t0=this;return E(function(u0){var v0=new q0(t0,new k0(s0));return new n(r0(v0).Subscribe(B),v0.Connect());});},Replay:function(r0,s0,t0,u0){if(u0===a)u0=v;if(r0===a)return new q0(this,new m0(s0,t0,u0));var v0=this;return E(function(w0){var x0=new q0(v0,new m0(s0,t0,u0));return new n(r0(x0).Subscribe(B),x0.Connect());});},SkipLast:function(r0){var s0=this;return E(function(t0){var u0=[];return s0.Subscribe(function(v0){u0.push(v0);if(u0.length>r0)t0.OnNext(u0.shift());},function(v0){t0.OnError(v0);},function(){t0.OnCompleted();});});},TakeLast:function(r0){var s0=this;return E(function(t0){var u0=[];return s0.Subscribe(function(v0){u0.push(v0);if(u0.length>r0)u0.shift();},function(v0){t0.OnError(v0);},function(){while(u0.length>0)t0.OnNext(u0.shift());t0.OnCompleted();});});}};var H=D.Merge=function(r0,s0){if(s0===a)s0=z;return J(r0,s0).MergeObservable();};var I=D.Concat=function(r0,s0){if(s0===a)s0=z;return E(function(t0){var u0=new o();var v0=0;var w0=s0.ScheduleRecursive(function(x0){if(v0<r0.length){var y0=r0[v0];v0++;var z0=new o();u0.Replace(z0);z0.Replace(y0.Subscribe(function(A0){t0.OnNext(A0);},function(A0){t0.OnError(A0);},x0));}else t0.OnCompleted();});return new n(u0,w0);});};var J=D.FromArray=function(r0,s0){if(s0===a)s0=z;return E(function(t0){var u0=0;return s0.ScheduleRecursive(function(v0){if(u0<r0.length){t0.OnNext(r0[u0++]);v0();}else t0.OnCompleted();});});};var K=D.Return=function(r0,s0){if(s0===a)s0=z;return E(function(t0){return s0.Schedule(function(){t0.OnNext(r0);t0.OnCompleted();});});};var L=D.Throw=function(r0,s0){if(s0===a)s0=z;return E(function(t0){return s0.Schedule(function(){t0.OnError(r0);});});};var M=D.Never=function(){return E(function(r0){return j;});};var N=D.Empty=function(r0){if(r0===a)r0=z;return E(function(s0){return r0.Schedule(function(){s0.OnCompleted();});});};var O=D.Defer=function(r0){return E(function(s0){var t0;try{t0=r0();}catch(u0){s0.OnError(u0);return j;}return t0.Subscribe(s0);});};var P=D.Catch=function(r0,s0){if(s0===a)s0=z;return E(function(t0){var u0=new o();var v0=0;var w0=s0.ScheduleRecursive(function(x0){var y0=r0[v0];v0++;var z0=new o();u0.Replace(z0);z0.Replace(y0.Subscribe(function(A0){t0.OnNext(A0);},function(A0){if(v0<r0.length)x0(); else t0.OnError(A0);},function(){t0.OnCompleted();}));});return new n(u0,w0);});};var Q=D.Using=function(r0,s0){return E(function(t0){var u0;var v0=j;try{var w0=r0();if(w0!==a)v0=w0;u0=s0(w0);}catch(x0){return new n(Throw(x0).Subscribe(t0),v0);}return new n(u0.Subscribe(t0),v0);});};var R=D.Range=function(r0,s0,t0){if(t0===a)t0=z;var u0=r0+s0-1;return T(r0,function(v0){return v0<=u0;},function(v0){return v0+1;},h,t0);};var S=D.Repeat=function(r0,s0,t0){if(t0===a)t0=z;if(s0===a)s0=-1;var u0=s0;return E(function(v0){return t0.ScheduleRecursive(function(w0){v0.OnNext(r0);if(u0>0){u0--;if(u0==0){v0.OnCompleted();return;}}w0();});});};var T=D.Generate=function(r0,s0,t0,u0,v0){if(v0===a)v0=z;return E(function(w0){var x0=r0;var y0=true;return v0.ScheduleRecursive(function(z0){var A0=false;var B0;try{if(y0)y0=false; else x0=t0(x0);A0=s0(x0);if(A0)B0=u0(x0);}catch(C0){w0.OnError(C0);return;}if(A0){w0.OnNext(B0);z0();}else w0.OnCompleted();});});};var U=D.GenerateWithTime=function(r0,s0,t0,u0,v0,w0){if(w0===a)w0=A;return new E(function(x0){var y0=r0;var z0=true;var A0=false;var B0;var C0;return w0.ScheduleRecursiveWithTime(function(D0){if(A0)x0.OnNext(B0);try{if(z0)z0=false; else y0=t0(y0);A0=s0(y0);if(A0){B0=u0(y0);C0=v0(y0);}}catch(E0){x0.OnError(E0);return;}if(A0)D0(C0); else x0.OnCompleted();},0);});};var V=D.OnErrorResumeNext=function(r0,s0){if(s0===a)s0=z;return E(function(t0){var u0=new o();var v0=0;var w0=s0.ScheduleRecursive(function(x0){if(v0<r0.length){var y0=r0[v0];v0++;var z0=new o();u0.Replace(z0);z0.Replace(y0.Subscribe(function(A0){t0.OnNext(A0);},x0,x0));}else t0.OnCompleted();});return new n(u0,w0);});};var W=D.Amb=function(){var r0=arguments;return E(function(s0){var t0=new n();var u0=new o();u0.Replace(t0);var v0=false;for(var w0=0;w0<r0.length;w0++){var x0=r0[w0];var y0=new o();var z0=new B(function(A0){if(!v0){t0.Remove(this.z,true);t0.Dispose();u0.Replace(this.z);v0=true;}s0.OnNext(A0);},function(A0){s0.OnError(A0);u0.Dispose();},function(){s0.OnCompleted();u0.Dispose();});z0.z=y0;y0.Replace(x0.Subscribe(z0));t0.Add(y0);}return u0;});};var X=D.ForkJoin=function(){var r0=arguments;return E(function(s0){var t0=[];var u0=[];var v0=[];var w0=new n();for(var x0=0;x0<r0.length;x0++) (function(y0){w0.Add(r0[y0].Subscribe(function(z0){t0[y0]=true;v0[y0]=z0;},function(z0){s0.OnError(z0);},function(z0){if(!t0[y0]){s0.OnCompleted();v0=a;t0=a;return;}u0[y0]=true;var A0=true;for(var B0=0;B0<r0.length;B0++){if(!u0[B0])A0=false;}if(A0){s0.OnNext(v0);s0.OnCompleted();v0=a;u0=a;t0=a;}}));})(x0);return w0;});};var Y=D.Interval=function(r0,s0){return a0(r0,r0,s0);};var Z=function(r0){return Math.max(0,r0);};var a0=D.Timer=function(r0,s0,t0){if(t0===a)t0=A;if(r0===a)return M();if(r0 instanceof Date)return O(function(){return D.Timer(r0-new Date(),s0,t0);});var u0=Z(r0);if(s0===a)return E(function(w0){return t0.ScheduleWithTime(function(){w0.OnNext(0);w0.OnCompleted();},u0);});var v0=Z(s0);return E(function(w0){var x0=0;return t0.ScheduleRecursiveWithTime(function(y0){w0.OnNext(x0++);y0(v0);},u0);});};var b0=D.While=function(r0,s0){return E(function(t0){var u0=new o();var v0=new n(u0);v0.Add(z.ScheduleRecursive(function(w0){var x0;try{x0=r0();}catch(y0){t0.OnError(y0);return;}if(x0)u0.Replace(s0.Subscribe(function(y0){t0.OnNext(y0);},function(y0){t0.OnError(y0);},function(){w0();})); else t0.OnCompleted();}));return v0;});};var c0=D.If=function(r0,s0,t0){if(t0===a)t0=N();return O(function(){return r0()?s0:t0;});};var d0=D.DoWhile=function(r0,s0){return I([r0,b0(s0,r0)]);};var e0=D.Case=function(r0,s0,t0,u0){if(u0===a)u0=z;if(t0===a)t0=N(u0);return O(function(){var v0=s0[r0()];if(v0===a)v0=t0;return v0;});};var f0=D.For=function(r0,s0){return E(function(t0){var u0=new n();var v0=0;u0.Add(z.ScheduleRecursive(function(w0){if(v0<r0.length){var x0;try{x0=s0(r0[v0]);}catch(y0){t0.OnError(y0);return;}u0.Add(x0.Subscribe(function(y0){t0.OnNext(y0);},function(y0){t0.OnError(y0);},function(){v0++;w0();}));}else t0.OnCompleted();}));return u0;});};var g0=D.Let=function(r0,s0){return O(function(){return s0(r0);});};var h0=b.Notification=function(r0,s0){this.Kind=r0;this.Value=s0;this.toString=function(){return this.Kind+": "+this.Value;};this.Accept=function(t0){switch(this.Kind){case "N":t0.OnNext(this.Value);break;case "E":t0.OnError(this.Value);break;case "C":t0.OnCompleted();break;}return j;};this.w=function(t0){var u0=this.Accept(t0);if(r0=="N")t0.OnCompleted();return u0;};};h0.prototype=new D;var i0=b.Subject=function(){var r0=new q();var s0=false;this.OnNext=function(t0){if(!s0){var u0=r0.ToArray();for(var v0=0;v0<u0.length;v0++){var w0=u0[v0];w0.OnNext(t0);}}};this.OnError=function(t0){if(!s0){var u0=r0.ToArray();for(var v0=0;v0<u0.length;v0++){var w0=u0[v0];w0.OnError(t0);}s0=true;r0.Clear();}};this.OnCompleted=function(){if(!s0){var t0=r0.ToArray();for(var u0=0;u0<t0.length;u0++){var v0=t0[u0];v0.OnCompleted();}s0=true;r0.Clear();}};this.w=function(t0){if(!s0){r0.Add(t0);return i(function(){r0.Remove(t0);});}else return j;};};i0.prototype=new D;for(var j0 in B.prototype) i0.prototype[j0]=B.prototype[j0];var k0=b.AsyncSubject=function(r0){var s0=new q();var t0;var u0=false;if(r0===a)r0=z;this.OnNext=function(v0){if(!u0)t0=new h0("N",v0);};this.OnError=function(v0){if(!u0){t0=new h0("E",v0);var w0=s0.ToArray();for(var x0=0;x0<w0.length;x0++){var y0=w0[x0];if(y0!==a)y0.OnError(v0);}u0=true;s0.Clear();}};this.OnCompleted=function(){if(!u0){if(t0===a)t0=new h0("C");var v0=s0.ToArray();for(var w0=0;w0<v0.length;w0++){var x0=v0[w0];if(x0!==a)t0.w(x0);}u0=true;s0.Clear();}};this.w=function(v0){if(!u0){s0.Add(v0);return i(function(){s0.Remove(v0);});}else return r0.Schedule(function(){t0.w(v0);});};};k0.prototype=new i0;var l0=b.BehaviorSubject=function(r0,s0){var t0=new m0(1,-1,s0);t0.OnNext(r0);return t0;};var m0=b.ReplaySubject=function(r0,s0,t0){var u0=new q();var v0=new q();var w0=false;if(t0===a)t0=v;var x0=s0>0;var y0=function(z0,A0){v0.Add({Value:new h0(z0,A0),Timestamp:t0.Now()});};this.A=function(){if(r0!==a)while(v0.GetCount()>r0)v0.RemoveAt(0);if(x0)while(v0.GetCount()>0&&t0.Now()-v0.GetItem(0).Timestamp>s0)v0.RemoveAt(0);};this.OnNext=function(z0){if(!w0){var A0=u0.ToArray();for(var B0=0;B0<A0.length;B0++){var C0=A0[B0];C0.OnNext(z0);}y0("N",z0);}};this.OnError=function(z0){if(!w0){var A0=u0.ToArray();for(var B0=0;B0<A0.length;B0++){var C0=A0[B0];C0.OnError(z0);}w0=true;u0.Clear();y0("E",z0);}};this.OnCompleted=function(){if(!w0){var z0=u0.ToArray();for(var A0=0;A0<z0.length;A0++){var B0=z0[A0];B0.OnCompleted();}w0=true;u0.Clear();y0("C");}};this.w=function(z0){var A0=new n0(this,z0);var B0=new n(A0);var C0=this;B0.Add(t0.Schedule(function(){if(!A0.B){C0.A();for(var D0=0;D0<v0.GetCount();D0++) v0.GetItem(D0).Value.Accept(z0);u0.Add(z0);A0.C=true;}}));return B0;};this.D=function(z0){u0.Remove(z0);};};m0.prototype=new i0;var n0=function(r0,s0){this.E=r0;this.F=s0;this.C=false;this.B=false;this.Dispose=function(){if(this.C)this.E.D(this.F);this.B=true;};};var o0=D.ToAsync=function(r0,s0){if(s0===a)s0=A;return function(){var t0=new k0(s0);var u0=function(){var x0;try{x0=r0.apply(this,arguments);}catch(y0){t0.OnError(y0);return;}t0.OnNext(x0);t0.OnCompleted();};var v0=this;var w0=p(arguments);s0.Schedule(function(){u0.apply(v0,w0);});return t0;};};var p0=D.Start=function(r0,s0,t0,u0){if(t0===a)t0=[];return o0(r0,u0).apply(s0,t0);};var q0=b.ConnectableObservable=function(r0,s0){if(s0===a)s0=new i0();this.E=s0;this.G=r0;this.H=false;this.Connect=function(){var t0;var u0=false;if(!this.H){this.H=true;var v0=this;t0=new n(i(function(){v0.H=false;}));this.I=t0;t0.Add(r0.Subscribe(this.E));}return this.I;};this.w=function(t0){return this.E.Subscribe(t0);};this.RefCount=function(){var t0=0;var u0=this;var v0;return F(function(w0){var x0=false;t0++;x0=t0==1;var y0=u0.Subscribe(w0);if(x0)v0=u0.Connect();return function(){y0.Dispose();t0--;if(t0==0)v0.Dispose();};});};};q0.prototype=new D;})();
// Copyright (c) Microsoft Corporation.  All rights reserved.
// This code is licensed by Microsoft Corporation under the terms
// of the MICROSOFT REACTIVE EXTENSIONS FOR JAVASCRIPT AND .NET LIBRARIES License.
// See http://go.microsoft.com/fwlink/?LinkId=186234.
(function()
{
var _jQuery = jQuery;
var proto = _jQuery.fn;
var global = this;
var root;
if (typeof ProvideCustomRxRootObject == "undefined")
{
root = global.Rx;
}
else
{
root = ProvideCustomRxRootObject();
}
var observable = root.Observable;
var asyncSubject = root.AsyncSubject;
var observableCreate = observable.Create;
var disposableEmpty = root.Disposable.Empty;
proto.toObservable = function(eventType, eventData)
{
var parent = this;
return observableCreate(function(observer)
{
var handler = function(eventObject)
{
observer.OnNext(eventObject);
};
parent.bind(eventType, eventData, handler);
return function()
{
parent.unbind(eventType, handler);
};
});
};
proto.toLiveObservable = function(eventType, eventData)
{
var parent = this;
return observableCreate(function(observer)
{
var handler = function(eventObject)
{
observer.OnNext(eventObject);
};
parent.live(eventType, eventData, handler);
return function()
{
parent.die(eventType, handler);
};
});
};
proto.hideAsObservable = function(duration)
{
var subject = new asyncSubject();
this.hide(duration, function()
{
subject.OnNext(this);
subject.OnCompleted();
});
return subject;
}
proto.showAsObservable = function(duration)
{
var subject = new asyncSubject();
this.show(duration, function()
{
subject.OnNext(this);
subject.OnCompleted();
});
return subject;
}
proto.animateAsObservable = function(properties, duration, easing)
{
var subject = new asyncSubject();
this.animate(properties, duration, easing, function()
{
subject.OnNext(this);
subject.OnCompleted();
});
return subject;
}
proto.fadeInAsObservable = function(duration)
{
var subject = new asyncSubject();
this.fadeIn(duration, function()
{
subject.OnNext(this);
subject.OnCompleted();
});
return subject;
}
proto.fadeToAsObservable = function(duration, opacity)
{
var subject = new asyncSubject();
this.fadeTo(duration, opacity, function()
{
subject.OnNext(this);
subject.OnCompleted();
});
return subject;
}
proto.fadeOutAsObservable = function(duration)
{
var subject = new asyncSubject();
this.fadeOut(duration, function()
{
subject.OnNext(this);
subject.OnCompleted();
});
return subject;
}
proto.slideDownAsObservable = function(duration)
{
var subject = new asyncSubject();
this.slideDown(duration, function()
{
subject.OnNext(this);
subject.OnCompleted();
});
return subject;
}
proto.slideUpAsObservable = function(duration)
{
var subject = new asyncSubject();
this.slideUp(duration, function()
{
subject.OnNext(this);
subject.OnCompleted();
});
return subject;
}
proto.slideToggleAsObservable = function(duration)
{
var subject = new asyncSubject();
this.slideToggle(duration, function()
{
subject.OnNext(this);
subject.OnCompleted();
});
return subject;
}
var ajaxAsObservable = _jQuery.ajaxAsObservable = function(settings)
{
var internalSettings = {};
for (var k in settings)
{
internalSettings[k] = settings[k];
}
var subject = new asyncSubject();
internalSettings.success = function(data, textStatus, xmlHttpRequest)
{
subject.OnNext({ data: data, textStatus: textStatus, xmlHttpRequest: xmlHttpRequest });
subject.OnCompleted();
};
internalSettings.error = function(xmlHttpRequest, textStatus, errorThrown)
{
subject.OnError({ xmlHttpRequest: xmlHttpRequest, textStatus: textStatus, errorThrown: errorThrown });
};
_jQuery.ajax(internalSettings);
return subject;
};
_jQuery.getJSONAsObservable = function(url, data)
{
return ajaxAsObservable({ url: url, dataType: 'json', data: data });
};
_jQuery.getScriptAsObservable = function(url, data)
{
return ajaxAsObservable({ url: url, dataType: 'script', data: data });
};
_jQuery.postAsObservable = function(url, data)
{
return ajaxAsObservable({ url: url, type: 'POST', data: data });
};
proto.loadAsObservable = function(url, params)
{
var subject = new asyncSubject();
var callback = function(response, status, xmlHttpRequest)
{
if (status === "error")
{
subject.OnError({ response : response, status : status, xmlHttpRequest: xmlHttpRequest });
}
else
{
subject.OnNext({ response : response, status : status, xmlHttpRequest: xmlHttpRequest });
subject.OnCompleted();
}
};
this.load(url, params, callback);
return subject;
};
_jQuery.getScriptAsObservable = function(url)
{
return ajaxAsObservable({ url: url, dataType: 'script'});
};
_jQuery.postAsObservable = function(url, data, type )
{
return ajaxAsObservable({ url : url, dataType : type, data : data, type : "POST" });
};
})();
/*
* Date Format 1.2.3
* (c) 2007-2009 Steven Levithan <stevenlevithan.com>
* MIT license
*
* Includes enhancements by Scott Trenda <scott.trenda.net>
* and Kris Kowal <cixar.com/~kris.kowal/>
*
* Accepts a date, a mask, or a date and a mask.
* Returns a formatted version of the given date.
* The date defaults to the current date/time.
* The mask defaults to dateFormat.masks.default.
*/
var dateFormat = function () {
var	token = /d{1,4}|m{1,4}|yy(?:yy)?|([HhMsTt])\1?|[LloSZ]|"[^"]*"|'[^']*'/g,
timezone = /\b(?:[PMCEA][SDP]T|(?:Pacific|Mountain|Central|Eastern|Atlantic) (?:Standard|Daylight|Prevailing) Time|(?:GMT|UTC)(?:[-+]\d{4})?)\b/g,
timezoneClip = /[^-+\dA-Z]/g,
pad = function (val, len) {
val = String(val);
len = len || 2;
while (val.length < len) val = "0" + val;
return val;
};
// Regexes and supporting functions are cached through closure
return function (date, mask, utc) {
var dF = dateFormat;
// You can't provide utc if you skip other args (use the "UTC:" mask prefix)
if (arguments.length == 1 && Object.prototype.toString.call(date) == "[object String]" && !/\d/.test(date)) {
mask = date;
date = undefined;
}
// Passing date through Date applies Date.parse, if necessary
date = date ? new Date(date) : new Date;
if (isNaN(date)) throw SyntaxError("invalid date");
mask = String(dF.masks[mask] || mask || dF.masks["default"]);
// Allow setting the utc argument via the mask
if (mask.slice(0, 4) == "UTC:") {
mask = mask.slice(4);
utc = true;
}
var	_ = utc ? "getUTC" : "get",
d = date[_ + "Date"](),
D = date[_ + "Day"](),
m = date[_ + "Month"](),
y = date[_ + "FullYear"](),
H = date[_ + "Hours"](),
M = date[_ + "Minutes"](),
s = date[_ + "Seconds"](),
L = date[_ + "Milliseconds"](),
o = utc ? 0 : date.getTimezoneOffset(),
flags = {
d:    d,
dd:   pad(d),
ddd:  dF.i18n.dayNames[D],
dddd: dF.i18n.dayNames[D + 7],
m:    m + 1,
mm:   pad(m + 1),
mmm:  dF.i18n.monthNames[m],
mmmm: dF.i18n.monthNames[m + 12],
yy:   String(y).slice(2),
yyyy: y,
h:    H % 12 || 12,
hh:   pad(H % 12 || 12),
H:    H,
HH:   pad(H),
M:    M,
MM:   pad(M),
s:    s,
ss:   pad(s),
l:    pad(L, 3),
L:    pad(L > 99 ? Math.round(L / 10) : L),
t:    H < 12 ? "a"  : "p",
tt:   H < 12 ? "am" : "pm",
T:    H < 12 ? "A"  : "P",
TT:   H < 12 ? "AM" : "PM",
Z:    utc ? "UTC" : (String(date).match(timezone) || [""]).pop().replace(timezoneClip, ""),
o:    (o > 0 ? "-" : "+") + pad(Math.floor(Math.abs(o) / 60) * 100 + Math.abs(o) % 60, 4),
S:    ["th", "st", "nd", "rd"][d % 10 > 3 ? 0 : (d % 100 - d % 10 != 10) * d % 10]
};
return mask.replace(token, function ($0) {
return $0 in flags ? flags[$0] : $0.slice(1, $0.length - 1);
});
};
}();
// Some common format strings
dateFormat.masks = {
"default":      "ddd mmm dd yyyy HH:MM:ss",
shortDate:      "m/d/yy",
mediumDate:     "mmm d, yyyy",
longDate:       "mmmm d, yyyy",
fullDate:       "dddd, mmmm d, yyyy",
shortTime:      "h:MM TT",
mediumTime:     "h:MM:ss TT",
longTime:       "h:MM:ss TT Z",
isoDate:        "yyyy-mm-dd",
isoTime:        "HH:MM:ss",
isoDateTime:    "yyyy-mm-dd'T'HH:MM:ss",
isoUtcDateTime: "UTC:yyyy-mm-dd'T'HH:MM:ss'Z'"
};
// Internationalization strings
dateFormat.i18n = {
dayNames: [
"Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat",
"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
],
monthNames: [
"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec",
"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
]
};
// For convenience...
Date.prototype.format = function (mask, utc) {
return dateFormat(this, mask, utc);
};
/* A JavaScript implementation of the SHA family of hashes, as defined in FIPS
* PUB 180-2 as well as the corresponding HMAC implementation as defined in
* FIPS PUB 198a
*
* Version 1.3 Copyright Brian Turek 2008-2010
* Distributed under the BSD License
* See http://jssha.sourceforge.net/ for more information
*
* Several functions taken from Paul Johnson
*/
(function(){var charSize=8,b64pad="",hexCase=0,str2binb=function(a){var b=[],mask=(1<<charSize)-1,length=a.length*charSize,i;for(i=0;i<length;i+=charSize){b[i>>5]|=(a.charCodeAt(i/charSize)&mask)<<(32-charSize-(i%32))}return b},hex2binb=function(a){var b=[],length=a.length,i,num;for(i=0;i<length;i+=2){num=parseInt(a.substr(i,2),16);if(!isNaN(num)){b[i>>3]|=num<<(24-(4*(i%8)))}else{return"INVALID HEX STRING"}}return b},binb2hex=function(a){var b=(hexCase)?"0123456789ABCDEF":"0123456789abcdef",str="",length=a.length*4,i,srcByte;for(i=0;i<length;i+=1){srcByte=a[i>>2]>>((3-(i%4))*8);str+=b.charAt((srcByte>>4)&0xF)+b.charAt(srcByte&0xF)}return str},binb2b64=function(a){var b="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"+"0123456789+/",str="",length=a.length*4,i,j,triplet;for(i=0;i<length;i+=3){triplet=(((a[i>>2]>>8*(3-i%4))&0xFF)<<16)|(((a[i+1>>2]>>8*(3-(i+1)%4))&0xFF)<<8)|((a[i+2>>2]>>8*(3-(i+2)%4))&0xFF);for(j=0;j<4;j+=1){if(i*8+j*6<=a.length*32){str+=b.charAt((triplet>>6*(3-j))&0x3F)}else{str+=b64pad}}}return str},rotl=function(x,n){return(x<<n)|(x>>>(32-n))},parity=function(x,y,z){return x^y^z},ch=function(x,y,z){return(x&y)^(~x&z)},maj=function(x,y,z){return(x&y)^(x&z)^(y&z)},safeAdd_2=function(x,y){var a=(x&0xFFFF)+(y&0xFFFF),msw=(x>>>16)+(y>>>16)+(a>>>16);return((msw&0xFFFF)<<16)|(a&0xFFFF)},safeAdd_5=function(a,b,c,d,e){var f=(a&0xFFFF)+(b&0xFFFF)+(c&0xFFFF)+(d&0xFFFF)+(e&0xFFFF),msw=(a>>>16)+(b>>>16)+(c>>>16)+(d>>>16)+(e>>>16)+(f>>>16);return((msw&0xFFFF)<<16)|(f&0xFFFF)},coreSHA1=function(f,g){var W=[],a,b,c,d,e,T,i,t,appendedMessageLength,H=[0x67452301,0xefcdab89,0x98badcfe,0x10325476,0xc3d2e1f0],K=[0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x5a827999,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x6ed9eba1,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0x8f1bbcdc,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6,0xca62c1d6];f[g>>5]|=0x80<<(24-(g%32));f[(((g+65)>>9)<<4)+15]=g;appendedMessageLength=f.length;for(i=0;i<appendedMessageLength;i+=16){a=H[0];b=H[1];c=H[2];d=H[3];e=H[4];for(t=0;t<80;t+=1){if(t<16){W[t]=f[t+i]}else{W[t]=rotl(W[t-3]^W[t-8]^W[t-14]^W[t-16],1)}if(t<20){T=safeAdd_5(rotl(a,5),ch(b,c,d),e,K[t],W[t])}else if(t<40){T=safeAdd_5(rotl(a,5),parity(b,c,d),e,K[t],W[t])}else if(t<60){T=safeAdd_5(rotl(a,5),maj(b,c,d),e,K[t],W[t])}else{T=safeAdd_5(rotl(a,5),parity(b,c,d),e,K[t],W[t])}e=d;d=c;c=rotl(b,30);b=a;a=T}H[0]=safeAdd_2(a,H[0]);H[1]=safeAdd_2(b,H[1]);H[2]=safeAdd_2(c,H[2]);H[3]=safeAdd_2(d,H[3]);H[4]=safeAdd_2(e,H[4])}return H},jsSHA=function(a,b){this.sha1=null;this.strBinLen=null;this.strToHash=null;if("HEX"===b){if(0!==(a.length%2)){return"TEXT MUST BE IN BYTE INCREMENTS"}this.strBinLen=a.length*4;this.strToHash=hex2binb(a)}else if(("ASCII"===b)||('undefined'===typeof(b))){this.strBinLen=a.length*charSize;this.strToHash=str2binb(a)}else{return"UNKNOWN TEXT INPUT TYPE"}};jsSHA.prototype={getHash:function(a){var b=null,message=this.strToHash.slice();switch(a){case"HEX":b=binb2hex;break;case"B64":b=binb2b64;break;default:return"FORMAT NOT RECOGNIZED"}if(null===this.sha1){this.sha1=coreSHA1(message,this.strBinLen)}return b(this.sha1)},getHMAC:function(a,b,c){var d,keyToUse,i,retVal,keyBinLen,keyWithIPad=[],keyWithOPad=[];switch(c){case"HEX":d=binb2hex;break;case"B64":d=binb2b64;break;default:return"FORMAT NOT RECOGNIZED"}if("HEX"===b){if(0!==(a.length%2)){return"KEY MUST BE IN BYTE INCREMENTS"}keyToUse=hex2binb(a);keyBinLen=a.length*4}else if("ASCII"===b){keyToUse=str2binb(a);keyBinLen=a.length*charSize}else{return"UNKNOWN KEY INPUT TYPE"}if(64<(keyBinLen/8)){keyToUse=coreSHA1(keyToUse,keyBinLen);keyToUse[15]&=0xFFFFFF00}else if(64>(keyBinLen/8)){keyToUse[15]&=0xFFFFFF00}for(i=0;i<=15;i+=1){keyWithIPad[i]=keyToUse[i]^0x36363636;keyWithOPad[i]=keyToUse[i]^0x5C5C5C5C}retVal=coreSHA1(keyWithIPad.concat(this.strToHash),512+this.strBinLen);retVal=coreSHA1(keyWithOPad.concat(retVal),672);return(d(retVal))}};window.jsSHA=jsSHA}());
jSaaspose.PortalService = function (applicationPath, useHttpHandlers, isWorkingCrossDomain) {
this._init(applicationPath, useHttpHandlers, isWorkingCrossDomain);
};
$.extend(jSaaspose.PortalService.prototype, {
_urlSuffix: "",
_lastError: null,
_service: null,
_cacheTimeout: 300,
applicationPath: null,
useJSONP: false,
_useHttpHandlers: false,
urlPrefix: "document-viewer",
_init: function (applicationPath, useHttpHandlers, isWorkingCrossDomain) {
this.applicationPath = applicationPath;
this._useHttpHandlers = useHttpHandlers;
if (useHttpHandlers)
this._urlSuffix = "Handler";
if ($.browser.msie && $.browser.version == 8 && isWorkingCrossDomain)
this.useJSONP = true;
},
viewDocumentAsHtml: function (userId, privateKey, path, preloadPagesCount, fileDisplayName, usePngImagesForHtmlBasedEngine,
convertWordDocumentsCompletely,
watermarkText, watermarkColor, watermarkPosition, watermarkWidth,
ignoreDocumentAbsence, supportPageRotation,
supportListOfContentControls, supportListOfBookmarks,
embedImagesIntoHtmlForWordFiles,
saveFontsInAllFormats,
successCallback, errorCallback, useCache, instanceIdToken, locale, passwordForOpening) {
var data = {
userId: userId, privateKey: privateKey, path: path, useHtmlBasedEngine: true,
preloadPagesCount: preloadPagesCount,
fileDisplayName: fileDisplayName,
usePngImagesForHtmlBasedEngine: usePngImagesForHtmlBasedEngine,
convertWordDocumentsCompletely: convertWordDocumentsCompletely,
ignoreDocumentAbsence: ignoreDocumentAbsence,
supportPageRotation: supportPageRotation,
supportListOfContentControls: supportListOfContentControls, supportListOfBookmarks: supportListOfBookmarks,
watermarkText: watermarkText, watermarkColor: watermarkColor, watermarkPosition: watermarkPosition, watermarkWidth: watermarkWidth,
embedImagesIntoHtmlForWordFiles: embedImagesIntoHtmlForWordFiles,
instanceIdToken: instanceIdToken,
locale: locale,
passwordForOpening: passwordForOpening,
saveFontsInAllFormats: saveFontsInAllFormats
};
this._runServiceAsync(this.applicationPath + this.urlPrefix + '/ViewDocument' + this._urlSuffix, data, successCallback, errorCallback, useCache != null ? useCache : false);
},
getDocumentPageHtml: function (path, pageIndex, usePngImages,
embedImagesIntoHtmlForWordFiles,
saveFontsInAllFormats,
successCallback, errorCallback,
instanceIdToken, locale) {
var data = {
path: path, pageIndex: pageIndex, usePngImages: usePngImages,
embedImagesIntoHtmlForWordFiles: embedImagesIntoHtmlForWordFiles,
instanceIdToken: instanceIdToken,
locale: locale,
saveFontsInAllFormats: saveFontsInAllFormats
};
this._runServiceAsync(this.applicationPath + this.urlPrefix + '/GetDocumentPageHtml' + this._urlSuffix, data, successCallback, errorCallback, false);
},
viewDocument: function (path, width, quality, usePdf, preloadPagesCount, password, fileDisplayName,
watermarkText, watermarkColor, watermarkPosition, watermarkWidth,
ignoreDocumentAbsence, supportPageRotation,
supportListOfContentControls, supportListOfBookmarks,
successCallback, errorCallback, useCache, instanceIdToken, locale, passwordForOpening) {
var data = {
path: path, width: width, quality: quality, usePdf: usePdf, preloadPagesCount: preloadPagesCount, password: password, fileDisplayName: fileDisplayName,
watermarkText: watermarkText, watermarkColor: watermarkColor, watermarkPosition: watermarkPosition, watermarkWidth: watermarkWidth,
ignoreDocumentAbsence: ignoreDocumentAbsence, supportPageRotation: supportPageRotation,
supportListOfContentControls: supportListOfContentControls, supportListOfBookmarks: supportListOfBookmarks,
instanceIdToken: instanceIdToken,
locale: locale,
passwordForOpening: passwordForOpening
};
this._runServiceAsync(this.applicationPath + this.urlPrefix + '/ViewDocument' + this._urlSuffix, data, successCallback, errorCallback, useCache != null ? useCache : false);
},
getPdf2JavaScript: function (userId, privateKey, path, descForHtmlBasedEngine, successCallback, errorCallback) {
var data = { path: path, descForHtmlBasedEngine: descForHtmlBasedEngine };
return this._runServiceAsync(this.applicationPath + this.urlPrefix + '/GetPdf2JavaScript' + this._urlSuffix, data, successCallback, errorCallback, false);
},
getImageUrlsAsync: function (userId, privateKey, path, width, token, firstPage, pageCount, quality, usePdf, docVersion,
watermarkText, watermarkColor, watermarkPosition, watermarkWidth,
ignoreDocumentAbsence,
useHtmlBasedEngine, supportPageRotation,
successCallback, errorCallback,
instanceIdToken, locale) {
var data = {
userId: userId,
privateKey: privateKey,
path: path,
width: width,
token: token,
firstPage: firstPage,
pageCount: pageCount,
quality: quality,
usePdf: usePdf,
docVersion: docVersion,
watermarkText: watermarkText,
watermarkColor: watermarkColor,
watermarkPosition: watermarkPosition,
watermarkWidth: watermarkWidth,
ignoreDocumentAbsence: ignoreDocumentAbsence,
useHtmlBasedEngine: useHtmlBasedEngine,
supportPageRotation: supportPageRotation,
instanceIdToken: instanceIdToken,
locale: locale
};
return this._runServiceAsync(this.applicationPath + this.urlPrefix + '/GetImageUrls' + this._urlSuffix, data, successCallback, errorCallback, false);
},
loadFileBrowserTreeData: function (userId, privateKey, path, pageIndex, pageSize, orderBy, orderAsc, filter, fileTypes, extended, successCallback, errorCallback, useCache, instanceIdToken) {
var data = { userId: userId, privateKey: privateKey, path: path, pageIndex: pageIndex, pageSize: pageSize, orderBy: orderBy, orderAsc: orderAsc, filter: filter, fileTypes: fileTypes, extended: extended, instanceIdToken: instanceIdToken };
return this._runServiceAsync(this.applicationPath + this.urlPrefix + '/LoadFileBrowserTreeData' + this._urlSuffix, data, successCallback, errorCallback, useCache != null ? useCache : true);
},
getPrintableHtml: function (path, useHtmlBasedEngine, fileDisplayName,
watermarkText, watermarkColor, watermarkPosition, watermarkWidth,
ignoreDocumentAbsence,
successCallback, errorCallback,
instanceIdToken, locale) {
var data = {
path: path, useHtmlBasedEngine: useHtmlBasedEngine, displayName: fileDisplayName,
watermarkText: watermarkText, watermarkColor: watermarkColor,
watermarkPosition: watermarkPosition, watermarkWidth: watermarkWidth,
ignoreDocumentAbsence: ignoreDocumentAbsence,
instanceIdToken: instanceIdToken,
locale: locale
};
return this._runServiceAsync(this.applicationPath + this.urlPrefix + '/GetPrintableHtml' + this._urlSuffix, data, successCallback, errorCallback, false);
},
reorderPage: function (path, oldPosition, newPosition, successCallback, errorCallback, instanceIdToken) {
var data = { path: path, oldPosition: oldPosition, newPosition: newPosition, instanceIdToken: instanceIdToken };
return this._runServiceAsync(this.applicationPath + this.urlPrefix + '/ReorderPage' + this._urlSuffix, data, successCallback, errorCallback, false);
},
rotatePage: function (path, pageNumber, rotationAmount, successCallback, errorCallback, instanceIdToken) {
var data = { path: path, pageNumber: pageNumber, rotationAmount: rotationAmount, instanceIdToken: instanceIdToken };
return this._runServiceAsync(this.applicationPath + this.urlPrefix + '/RotatePage' + this._urlSuffix, data, successCallback, errorCallback, false);
},
_runServiceSync: function (url, data, useCache) {
var r = null;
var serviceCallEnded = false;
var successCallback = function (response) {
serviceCallEnded = true;
r = response.data;
};
this._runService(url, data, false, successCallback, null, useCache);
return r;
},
_runServiceAsync: function (url, data, successCallback, errorCallback, useCache, convertToXml) {
return this._runService(url, data, true, successCallback, errorCallback, useCache, convertToXml);
},
_runService: function (url, data, mode, successCallback, errorCallback, useCache, convertToXml) {
var stringData = JSON.stringify(data);
var cacher = null;
if (useCache) {
cacher = Container.Resolve("Cacher");
var cacheItem = cacher.get(url + stringData);
if (cacheItem) {
cacheItem.value.Subscribe(function (response) {
this._successHandler(response, successCallback);
}.bind(this), function (ex) { this._errorHandler(ex, errorCallback); }.bind(this));
return cacheItem.value;
}
}
var dataToSend;
if (this.useJSONP) {
if (this._useHttpHandlers)
dataToSend = "data=" + stringData.toString();
else
dataToSend = data;
}
else {
dataToSend = stringData;
}
var requestObservable = Container.Resolve("RequestObservable")({
url: url,
type: this.useJSONP ? "GET" : "POST",
contentType: "application/json; charset=utf-8",
dataType: this.useJSONP ? "jsonp" + (convertToXml ? " xml" : "") : null,
//data: (this.useJSONP && this._useHttpHandlers) ? ("data=" + stringData.toString()) : stringData,
data: dataToSend,
async: mode
});
var finalHandler = Container.Resolve("AsyncSubject");
requestObservable.Finally = function (method) {
finalHandler.Subscribe(method);
};
requestObservable.Subscribe(
function (response) {
if (response) {
if (response.data.success === false) {
var error = { code: response.data.code, Reason: (response.data ? response.data.Reason : null) };
if (errorCallback) {
errorCallback(error);
}
}
else {
this._successHandler(response, successCallback);
}
}
finalHandler.OnNext();
finalHandler.OnCompleted();
}.bind(this),
function (ex) {
this._errorHandler(ex, errorCallback);
finalHandler.OnNext();
finalHandler.OnCompleted();
}.bind(this));
if (useCache) {
cacher.add(url + stringData, requestObservable, this._cacheTimeout);
}
return requestObservable;
},
_errorHandler: function (ex, errorCallback) {
var error = null;
if (ex.xmlHttpRequest.readyState == 0) {
if (ex.xmlHttpRequest.status === 0) {
error = { Reason: "Can't connect to server" };
}
else
return;
}
var errorCode = ex.xmlHttpRequest.status;
if (!error)
error = { Reason: ex.xmlHttpRequest.responseText };
try {
if (errorCallback) {
errorCallback(error);
}
}
catch (e) { }
},
_successHandler: function (response, successCallback) {
if (successCallback) {
if (response.xmlHttpRequest.responseText == '') {
response.data = null;
}
successCallback(response);
}
}
});
(function () {
var special = jQuery.event.special,
uid1 = 'D' + (+new Date()),
uid2 = 'D' + (+new Date() + 1);
special.scrollstart = {
setup: function () {
var timer,
handler = function (evt) {
var _self = this,
_args = arguments;
if (timer) {
clearTimeout(timer);
} else {
evt.type = 'scrollstart';
$(_self).trigger("scrollstart");
//jQuery.event.handle.apply(_self, _args);
}
timer = setTimeout(function () {
timer = null;
}, special.scrollstop.latency);
};
jQuery(this).bind('scroll', handler).data(uid1, handler);
},
teardown: function () {
jQuery(this).unbind('scroll', jQuery(this).data(uid1));
}
};
special.scrollstop = {
latency: 300,
setup: function () {
var timer,
handler = function (evt) {
var _self = this,
_args = arguments;
if (timer) {
clearTimeout(timer);
}
timer = setTimeout(function () {
timer = null;
evt.type = 'scrollstop';
$(_self).trigger("scrollstop");
//jQuery.event.handle.apply(_self, _args);
}, special.scrollstop.latency);
};
jQuery(this).bind('scroll', handler).data(uid2, handler);
},
teardown: function () {
jQuery(this).unbind('scroll', jQuery(this).data(uid2));
}
};
})();
(function ($, undefined) {
$.widget('ui.docViewer', {
_viewModel: null,
options: {
fileId: 0,
fileVersion: 1,
userId: 0,
userKey: null,
baseUrl: null,
_mode: 'full',
_docGuid: '',
quality: null,
use_pdf: "true",
showHyperlinks: true
},
_create: function () {
$.extend(this.options, {
documentSpace: this.element,
emptyImageUrl: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mNgYAAAAAMAASsJTYQAAAAASUVORK5CYII="
});
if (this.options.createHtml) {
this._createHtml();
}
this._viewModel = this.getViewModel();
ko.applyBindings(this._viewModel, this.element.get(0));
},
_init: function () {
$(this._viewModel).bind('getPagesCount', function (e, pagesCount) {
$(this.element).trigger('getPagesCount', [pagesCount]);
}.bind(this));
$(this._viewModel).bind('onDocumentLoaded', function (e, response) {
this.element.trigger('onDocumentLoaded', response);
}.bind(this));
$(this._viewModel).bind('onDocumentPasswordRequired', function (e) {
$(this.element).trigger('onDocumentPasswordRequired');
}.bind(this));
$(this._viewModel).bind('_onProcessPages', function (e, data) {
$(this.element).trigger('_onProcessPages', [data]);
}.bind(this));
$(this._viewModel).bind('onProcessPages', function (e, guid) {
$(this.element).trigger('onProcessPages', [guid]);
}.bind(this));
$(this._viewModel).bind('onScrollDocView', function (e, data) {
$(this.element).trigger('onScrollDocView', [data]);
}.bind(this));
$(this._viewModel).bind('onBeforeScrollDocView', function (e, data) {
$(this.element).trigger('onBeforeScrollDocView', [data]);
}.bind(this));
$(this._viewModel).bind('onDocumentLoadComplete', function (e, data, pdf2XmlWrapper) {
$(this.element).trigger('onDocumentLoadComplete', [data, pdf2XmlWrapper]);
}.bind(this));
$(this._viewModel).bind('onSearchPerformed', function (e, searchCountItem) {
$(this.element).trigger('onSearchPerformed', [searchCountItem]);
}.bind(this));
$(this._viewModel).bind('onPageImageLoaded', function (e) {
$(this.element).trigger('onPageImageLoaded');
}.bind(this));
$(this._viewModel).bind('onDocViewScrollPositionSet', function (e, data) {
$(this.element).trigger('onDocViewScrollPositionSet', [data]);
}.bind(this));
$(this._viewModel).bind('onDocumentPageSet', function (e, newPageIndex) {
$(this.element).trigger('onDocumentPageSet', [newPageIndex]);
}.bind(this));
},
getViewModel: function () {
if (this._viewModel == null) {
this._viewModel = this._createViewModel();
}
return this._viewModel;
},
_createViewModel: function () {
var vm = new docViewerViewModel(this.options);
return vm;
},
applyBindings: function () {
ko.applyBindings(this._viewModel, this.element.get(0));
},
_createHtml: function () {
var rotationMarkup;
if (this.options.supportPageRotation) {
rotationMarkup = ' + \' translateY(\' + (($root.isHtmlDocument() && $data.rotation() == 180) ? \'100%\' : \'0\') + \') \' +' +
' \'rotate(\' + $data.rotation() + \'deg)\' +' +
' \' translateX(\' + (($data.rotation() == 180 || $data.rotation() == 270) ? \'-100%\' : \'0\') + \')\' +' +
' \' translateY(\' + (($data.rotation() == 90 || (!$root.isHtmlDocument() && $data.rotation() == 180)) ? \'-100%\' : \'0\') + \') \'  ';
}
else {
rotationMarkup = "";
}
var msScale = '\'-ms-transform\': \'scale(\' + $data.heightRatio() * $root.zoom() / 100.0 + \')\' ';
if (this.options.pageContentType == "html" && $.browser.msie) {
if ($.browser.version == 8)
msScale = 'zoom: $data.heightRatio() * $root.zoom() / 100.0 ';
else {
msScale += rotationMarkup;
}
}
msScale += ",";
var htmlBasedWatermarkMarkup;
if (this.options.watermarkText) {
htmlBasedWatermarkMarkup =
'<svg xmlns="http://www.w3.org/2000/svg" class="html_watermark" data-bind="attr:{width: $root.pageWidth() + $root.imageHorizontalMargin + \'px\', height: $root.pageWidth() * $data.prop() + \'px\', viewBox:\'0 0 100 \' + 100 * $data.prop()}" pointer-events="none">' +
'<text data-bind="text:$root.watermarkText, style:{fill:$root.intToColor($root.watermarkColor)}, ' +
'attr:{transform:$root.watermarkTransform($data, $element), ' +
'y:$root.watermarkPosition.indexOf(\'Top\') == -1 ? 100 * $data.prop() :\'10\'}" font-family="Verdana" font-size="10" x="0" y="0" ></text>' +
'</svg>';
}
else {
htmlBasedWatermarkMarkup = "";
}
var htmlPageContentsWithTransformScaling =
'           <div class="html_page_contents"' +
'                 data-bind="' + (this.options.useVirtualScrolling ? 'parsedHtml' : 'html') + ': htmlContent(), ' +
'attr: { id:\'' + this.options.docViewerId + 'pageHtml-\' + number }, ' +
'searchText: searchText, ' +
'                        css: {chrome: $root.browserIsChrome(), \'page-image\': !$root.useTabsForPages()}, ' +
'                        style: { ' +
'                                 width: $root.rotatedWidth(), ' +
msScale +
'                                 MozTransform: \'scale(\' + $data.heightRatio() * $root.zoom() / 100.0  + \')\' ' + rotationMarkup + ', ' +
'                                 \'-webkit-transform\': \'scale(\' + $data.heightRatio() * $root.zoom() / 100.0  + \')\' ' + rotationMarkup +
'                               }">' +
'            </div>' + htmlBasedWatermarkMarkup;
var htmlPageContentsWithEmScaling =
'           <div class="page-image html_page_contents"' +
'                 data-bind="html: htmlContent, attr: { id:\'' + this.options.docViewerId + 'pageHtml-\' + number }, ' +
'                        searchText: searchText, ' +
'                        style:{fontSize: ($data.heightRatio() * 100.0) + \'%\'},' +
'                        css: {chrome: $root.browserIsChrome()} ">' +
'            </div>';
var htmlPageContents;
if (this.options.useEmScaling)
htmlPageContents = htmlPageContentsWithEmScaling;
else
htmlPageContents = htmlPageContentsWithTransformScaling;
var pagesContainerElementHtml;
var useHtmlBasedEngine = (this.options.pageContentType == "html");
if (useHtmlBasedEngine && this.options.useEmScaling) {
pagesContainerElementHtml = 'class="pages_container html_pages_container" data-bind="style:{fontSize: (16.* $root.zoom() / 100.0) + \'px\'}"';
}
else {
pagesContainerElementHtml = 'class="pages_container ' + (useHtmlBasedEngine ? 'html_pages_container' : '') + '" data-bind="style: { height: $root.useVirtualScrolling ? ($root.documentHeight() + \'px\') : \'auto\', width: ($root.layout() == $root.Layouts.TwoPagesInRow || $root.layout() == $root.Layouts.CoverThenTwoPagesInRow) ? ($root.pageWidth() + $root.imageHorizontalMargin) * 2 + \'px\': \'auto\'}"';
}
var viewerHtml =
'<div id="' + this.options.docViewerId + 'PagesContainer" ' + pagesContainerElementHtml + '>' +
'<!-- ko foreach: { data: $root.useVirtualScrolling ? pages.slice(firstVisiblePageForVirtualMode(), lastVisiblePageForVirtualMode() + 1) : pages, afterRender: function(){$root.highlightSearch();} } -->' +
'<div class="doc-page" data-bind="attr: {id: $root.pagePrefix + (($root.useVirtualScrolling ? $root.firstVisiblePageForVirtualMode() : 0) + $index() + 1)}, style: $root.pageElementStyle($index()), css: {cover_page: ($root.layout() == $root.Layouts.CoverThenTwoPagesInRow && ($root.useVirtualScrolling ? $root.firstVisiblePageForVirtualMode() : 0) + $index() == 0)}" >' +
//'       <div class="viewer_loading_overlay" data-bind="style: { zIndex: ($root.inprogress() || !visible() ? 2 : 0), width: $parent.pageWidth() + \'px\', height: $root.useTabsForPages() ? \'100%\' : ($parent.pageWidth() * $data.prop() + \'px\'), backgroundColor: ($root.inprogress() || !visible() ? \'\' : \'transparent\')}" style="width: 850px; height: 1100px;position: absolute;left:0;top:0">' +
'       <div class="viewer_loading_overlay" data-bind="visible: ($root.alwaysShowLoadingSpinner() || $root.inprogress() || !visible()), style: { zIndex: ($root.inprogress() || !visible() ? 2 : 0), width: $root.pageWidth() + \'px\', height: $parent.pageWidth() * $data.prop() + \'px\', backgroundColor: ($root.inprogress() || !visible() ? \'\' : \'transparent\')}" style="width: 850px; height: 1100px;position: absolute;left:0;top:0">' +
'           <div class="loading_overlay_message">' +
'               <span class="progresspin"></span>' +
'               <p data-localize="LoadingYourContent">Loading your content...</p>' +
'           </div>' +
'       </div>' +
(useHtmlBasedEngine ?
(
htmlPageContents
)
:
'           <div class="button-pane"></div>' +
'           <div class="highlight-pane"></div>' +
'           <div class="custom-pane"></div>' +
'           <div class="search-pane"></div>' +
'           <img class="page-image" src="' + this.options.emptyImageUrl + '" data-bind="event: {load: function(item, e){$root.firePageImageLoadedEvent($index(), e);}, error: function(item, e){$root.firePageImageLoadErrorEvent($index(), e);} }, attr: { id: \'' + this.options.docViewerId + '\' + \'-img-\' + ($index() + 1), src: (visible() ? url : $root.emptyImageUrl) }, ' +
'           style: { width: $parent.pageWidth() + \'px\', height: $parent.pageWidth() * $data.prop() + \'px\' }"/>'
) +
'   </div>' +
'<!-- /ko -->' +
'</div>' +
'<div class="tab_control_wrapper" data-bind="visible: useTabsForPages && tabs().length > 0">' +
'<ul class="doc_viewer_tab_control" data-bind="foreach: tabs, visible: useTabsForPages && tabs().length > 0">' +
'   <li data-bind="css:{active:$index() == $root.activeTab()}">' +
'      <a href="#" data-bind="text:name, click: function(){$root.activateTab($index());}"></a>' +
'   </li>' +
'</ul>' +
'</div>';
var root = this.element;
$(viewerHtml).appendTo(root);
root.trigger("onHtmlCreated");
this.element = $("#" + this.options.docViewerId);
}
});
// Doc Viewer Model
docViewerModel = function (options) {
$.extend(this, options);
this._init();
};
$.extend(docViewerModel.prototype, {
_init: function () {
this._portalService = Container.Resolve("PortalService");
},
loadDocument: function (fileId, pagesCountToShow, imageWidth, password, fileDisplayName,
watermarkText, watermarkColor, watermarkPosition, watermarkWidth,
ignoreDocumentAbsence,
supportPageRotation,
supportListOfContentControls, supportListOfBookmarks,
instanceIdToken,
callback, errorCallback,
locale, passwordForOpening) {
var self = this;
var onSucceded = function (response) {
var guid;
if (response.data != null) {
if (response.data.path && typeof response.data.guid == "undefined")
response.data.guid = response.data.path;
if (self._mode == 'webComponent')
guid = response.data.path;
else
guid = response.data.guid;
}
if (typeof guid !== "undefined") {
callback.apply(this, [response.data]);
}
else {
errorCallback.apply(this, [{ code: response.data.code, Reason: (response.data ? response.data.Reason : null) }]);
}
};
switch (this._mode) {
case 'embed':
this._portalService.viewEmbedDocumentAllAsync(this.userId, this.userKey, fileId, imageWidth, this.quality, this.use_pdf, this.preloadPagesCount, password, fileDisplayName, onSucceded, errorCallback);
break;
case 'webComponent':
this._portalService.viewDocument(fileId, imageWidth, this.quality, this.usePdf, this.preloadPagesCount, password, fileDisplayName,
watermarkText, watermarkColor, watermarkPosition, watermarkWidth,
ignoreDocumentAbsence, supportPageRotation,
supportListOfContentControls, supportListOfBookmarks,
onSucceded, errorCallback,
false,
instanceIdToken,
locale,
passwordForOpening
);
break;
case 'annotatedDocument':
this._portalService.viewAnnotatedDocumentAsync(this.userId, this.userKey, fileId, null, pagesCountToShow, imageWidth, null, this.quality, this.use_pdf, { text: watermarkText, color: watermarkColor, position: watermarkPosition, fontSize: watermarkWidth }, onSucceded, errorCallback, false);
break;
default:
this._portalService.viewDocumentAllAsync(this.userId, this.userKey, fileId, null, pagesCountToShow, imageWidth, null, this.quality, this.use_pdf, onSucceded, errorCallback, false);
break;
}
},
loadDocumentAsHtml: function (fileId, pagesCountToShow, fileDisplayName, usePngImages, convertWordDocumentsCompletely,
watermarkText, watermarkColor, watermarkPosition, watermarkWidth,
ignoreDocumentAbsence, supportPageRotation,
supportListOfContentControls, supportListOfBookmarks,
embedImagesIntoHtmlForWordFiles,
instanceIdToken,
saveFontsInAllFormats,
callback, errorCallback, locale, passwordForOpening) {
this._portalService.viewDocumentAsHtml(this.userId, this.userKey, fileId, this.preloadPagesCount, fileDisplayName, usePngImages,
convertWordDocumentsCompletely,
watermarkText, watermarkColor, watermarkPosition, watermarkWidth,
ignoreDocumentAbsence, supportPageRotation,
supportListOfContentControls, supportListOfBookmarks,
embedImagesIntoHtmlForWordFiles,
saveFontsInAllFormats,
function (response) {
if (response.data && typeof (response.data.path) !== "undefined") {
callback.apply(this, [response.data]);
}
else {
errorCallback.apply(this);
}
},
function (error) {
errorCallback.apply(this, [error]);
},
false,
instanceIdToken,
locale,
passwordForOpening
);
},
loadProperties: function (fileId, callback) {
this._portalService.getDocInfoAsync(this.userId, this.userKey, fileId,
function (response) {
callback.apply(this, [response.data]);
});
},
loadHyperlinks: function (fileId, callback, errorCallback) {
this._portalService.getDocumentHyperlinks(fileId,
function (response) {
callback.apply(this, [response.data]);
},
function (error) {
errorCallback.apply(this, [error]);
});
},
retrieveImageUrls: function (fileId, token, imageCount, pagesDimension,
watermarkText, watermarkColor,
watermarkPosition, watermarkWidth,
ignoreDocumentAbsence,
useHtmlBasedEngine,
supportPageRotation,
instanceIdToken,
callback, errorCallback,
locale) {
this._portalService.getImageUrlsAsync(this.userId, this.userKey, fileId, pagesDimension, token, 0, imageCount, this.quality == null ? '' : this.quality, this.use_pdf, this.fileVersion,
watermarkText, watermarkColor, watermarkPosition, watermarkWidth,
ignoreDocumentAbsence,
useHtmlBasedEngine, supportPageRotation,
function (response) {
callback.apply(this, [response.data]);
},
function (error) {
errorCallback.apply(this, [error]);
},
instanceIdToken,
locale
);
},
getDocumentPageHtml: function (fileId, pageNumber, usePngImages,
embedImagesIntoHtmlForWordFiles,
instanceIdToken,
saveFontsInAllFormats,
callback, errorCallback, locale) {
this._portalService.getDocumentPageHtml(fileId, pageNumber, usePngImages,
embedImagesIntoHtmlForWordFiles,
saveFontsInAllFormats,
function (response) {
callback.apply(this, [response.data]);
},
function (error) {
errorCallback.apply(this, [error]);
},
instanceIdToken,
locale
);
},
reorderPage: function (fileId, oldPosition, newPosition, instanceIdToken, callback, errorCallback) {
this._portalService.reorderPage(fileId, oldPosition, newPosition,
function (response) {
callback.apply(this, [response.data]);
},
function (error) {
errorCallback.apply(this, [error]);
},
instanceIdToken
);
},
rotatePage: function (path, pageNumber, rotationAmount, instanceIdToken, successCallback, errorCallback) {
this._portalService.rotatePage(path, pageNumber, rotationAmount,
function (response) {
successCallback.apply(this, [response.data]);
},
function (error) {
errorCallback.apply(this, [error]);
},
instanceIdToken
);
}
});
// Doc Viewer View Model
docViewerViewModel = function (options) {
$.extend(this, options);
this._create(options);
};
$.extend(docViewerViewModel.prototype, {
Layouts: { ScrollMode: 1, BookMode: 2, OnePageInRow: 3, TwoPagesInRow: 4, CoverThenTwoPagesInRow: 5 },
_model: null,
pagesDimension: null,
pageImageWidth: 0,
imageHorizontalMargin: 34,
imageVerticalMargin: 0,
initialZoom: 100,
zoom: null,
scale: null,
docWasLoadedInViewer: false,
scrollPosition: [0, 0],
inprogress: null,
pages: null,
pageInd: null,
pageWidth: null,
pageHeight: null,
pageCount: null,
docType: null,
fileId: null,
_dvselectable: null,
_thumbnailHeight: 140,
_firstPage: null,
_sessionToken: '',
imageUrls: [],
pagePrefix: "page-",
documentName: null,
fit90PercentWidth: false,
_pageBounds: null,
unscaledPageHeight: null,
unscaledPageWidth: null,
pageLeft: null,
preloadPagesCount: null,
viewerLayout: 1,
changedUrlHash: false,
hashPagePrefix: "page",
pageContentType: "image",
scrollbarWidth: null,
password: null,
useJavaScriptDocumentDescription: false,
minimumImageWidth: null,
fileDisplayName: null,
hyperlinks: null,
watermarkText: null,
watermarkWidth: null,
watermarkColor: null,
watermarkLeft: null,
watermarkTop: null,
watermarkScreenWidth: null,
searchText: null,
htmlSearchHighlightClassName: "search_highlight_html",
htmlSearchHighlightElement: "span",
htmlSearchHighlightSvgElement: "tspan",
currentWordCounter: 0,
matchedNods: null,
searchMatches: null,
matchedNodsCount: 0,
matchesCount: null,
searchSeparatorsList: "\\-[\\]{}()*+?\\\\^|\\s.,:;+\"/",
usePngImagesForHtmlBasedEngine: false,
loadAllPagesOnSearch: false,
serverPages: null,
convertWordDocumentsCompletely: false,
ignoreDocumentAbsence: false,
tabs: null,
useTabsForPages: null,
tabPanelHeight: 30,
supportPageRotation: false,
fileType: null,
activeTab: null,
autoHeight: null,
isHtmlDocument: null,
rotatedWidth: null,
alwaysShowLoadingSpinner: null,
supportListOfContentControls: false,
supportListOfBookmarks: false,
isDocumentLoaded: false,
_isTextPositionsCalculationFinished: true,
initStorageOnMouseStart: false,
options: {
showHyperlinks: true
},
_create: function (options) {
this._model = new docViewerModel(options);
this._init(options);
},
_init: function (options) {
var self = this;
this.initCustomBindings();
if (this.viewerLeft != 0) {
this.viewerWidth -= this.viewerLeft;
this.documentSpace.css("width", this.viewerWidth + "px");
}
var defaultPageImageWidth = 852;
var defaultPageImageHeight = 1100;
this.pageImageWidth = defaultPageImageWidth;
this.pages = ko.observableArray([]);
this.scale = ko.observable(this.initialZoom / 100);
this.inprogress = ko.observable(false),
this.pageLeft = ko.observable(0);
this.pageInd = ko.observable(1);
this.pageWidth = ko.observable(defaultPageImageWidth);
this.pageHeight = ko.observable(defaultPageImageHeight);
this.pageCount = ko.observable(0);
this.docType = ko.observable(-1);
this.documentName = ko.observable("");
this.password = ko.observable("");
this.preloadPagesCount = options.preloadPagesCount;
this.browserIsChrome = ko.observable(false);
this.hyperlinks = ko.observableArray();
this.useTabsForPages = ko.observable(null); // it's undefined
this.tabs = ko.observableArray([]);
this.activeTab = ko.observable(0);
this.autoHeight = ko.observable(false);
this.isHtmlDocument = ko.observable(false);
this.alwaysShowLoadingSpinner = ko.observable(false);
this.rotatedWidth = ko.computed(function () {
if (this.useTabsForPages()) {
var width;
width = this.pageWidth();
if (this.autoHeight())
return "auto";
return width / this.zoom() * 100.0 + "px";
}
else
return "auto";
}, this);
this.layout = ko.observable(this.viewerLayout);
this.firstVisiblePageForVirtualMode = ko.observable(0)
.extend({ rateLimit: { method: "notifyWhenChangesStop", timeout: 400 } });;
this.lastVisiblePageForVirtualMode = ko.observable(0)
.extend({ rateLimit: { method: "notifyWhenChangesStop", timeout: 400 } });;
this.documentHeight = ko.observable(0);
if (this.pageContentType == "html") {
this.imageHorizontalMargin = 0;
this.calculatePointToPixelRatio();
}
if (!this.docViewerId)
this.docViewerId = this.documentSpace.attr('id');
this.pagePrefix = this.docViewerId + "-page-";
if (options.fit90PercentWidth)
this.pageImageWidth = this.documentSpace.width() * 0.9 - 2 * this.imageHorizontalMargin;
if (this.pageContentType == "image")
this.initialWidth = this.pageImageWidth;
if (this.zoomToFitWidth) {
this.initialWidth = this.pageImageWidth = this.getFitWidth();
}
this.zoom = ko.observable(this.initialZoom);
this.documentHeight = ko.observable(0);
this.options.showHyperlinks = (options.showHyperlinks != false && this.use_pdf != 'false');
this.options.highlightColor = options.highlightColor;
this.matchedNods = [];
this.searchMatches = [];
this.serverPages = [{ w: this.initialWidth, h: 100 }];
var pageDescription;
if (this.pages().length == 0) {
pageDescription = { number: 1, visible: ko.observable(false), url: ko.observable(this.emptyImageUrl), htmlContent: ko.observable(""), searchText: ko.observable(null) };
if (this.supportPageRotation)
pageDescription.rotation = ko.observable(0);
if (this.variableHeightPageSupport) {
pageDescription.prop = ko.observable(1);
pageDescription.heightRatio = ko.observable(1);
}
if (this.useVirtualScrolling) {
pageDescription.left = 0;
pageDescription.top = ko.observable(0);
}
this.pages.push(pageDescription);
}
this.pagesContainerElement = this.documentSpace.find(".pages_container");
this.contentControlsFromHtml = new Array();
if (options.fileId) {
this.loadDocument();
}
else {
pageDescription.visible(true);
}
},
loadDocument: function (fileId) {
this.inprogress(true);
this.documentSpace.trigger('onDocumentloadingStarted');
var functionErrorCallback = function(error) {
this._onDocumentLoadFailed(error, fileId || this.fileId);
};
var pageCountToShow = 1;
if (this.pageContentType == "image") {
var pageWidth;
if (this.shouldMinimumWidthBeUsed(this.pageImageWidth * this.initialZoom / 100, false))
pageWidth = this.minimumImageWidth;
else
pageWidth = Math.round(this.pageImageWidth * this.initialZoom / 100);
this._model.loadDocument(fileId || this.fileId, pageCountToShow, pageWidth, this.password(), this.fileDisplayName,
this.watermarkText, this.watermarkColor, this.watermarkPosition, this.watermarkWidth,
this.ignoreDocumentAbsence, this.supportPageRotation,
this.supportListOfContentControls, this.supportListOfBookmarks,
this.instanceIdToken,
function (response) {
//this._onDocumentLoaded(response);
if (typeof (fileId) !== 'undefined')
this.fileId = fileId;
this.pageWidth(this.pageImageWidth * (this.initialZoom / 100));
this.zoom(this.initialZoom);
if (this.docWasLoadedInViewer)
this.setPageNumerInUrlHash(1);
this._onDocumentLoadedBeforePdf2Xml(response);
//this.preloadImages(response, this.preloadPagesCount);
}.bind(this),
functionErrorCallback.bind(this),
this.locale,
this.passwordForOpening
);
}
else if (this.pageContentType == "html") {
this._model.loadDocumentAsHtml(fileId || this.fileId, pageCountToShow, this.fileDisplayName, this.usePngImagesForHtmlBasedEngine,
this.convertWordDocumentsCompletely,
this.watermarkText, this.watermarkColor, this.watermarkPosition, this.watermarkWidth,
this.ignoreDocumentAbsence, this.supportPageRotation,
this.supportListOfContentControls, this.supportListOfBookmarks,
this.embedImagesIntoHtmlForWordFiles,
this.instanceIdToken,
this.saveFontsInAllFormats,
function (response) {
if (typeof (fileId) !== 'undefined')
this.fileId = fileId;
this.pageWidth(this.pageImageWidth * (this.initialZoom / 100));
this._onDocumentLoadedBeforePdf2Xml(response);
//this._onDocumentLoaded(response);
}.bind(this),
functionErrorCallback.bind(this),
this.locale,
this.passwordForOpening
);
}
if (typeof viewModelPathOnlineDoc !== 'undefined')
viewModelPathOnlineDoc.pathOnlineDoc('');
},
getDocumentPageHtml: function (pageNumber, successCallback) {
var page;
if (this.useTabsForPages()) {
page = this.tabs()[pageNumber];
}
else {
page = this.pages()[pageNumber];
}
if (!page.visible() && !page.startedDownloadingPage) {
var pageHtml = this.preloadedPages && this.preloadedPages.html[pageNumber];
if (pageHtml) {
page.htmlContent(pageHtml);
var pageCss = this.preloadedPages.css[pageNumber];
this.setPageHtml(page, pageNumber, pageHtml, pageCss);
if (successCallback)
successCallback.call();
return;
}
page.startedDownloadingPage = true;
this._model.getDocumentPageHtml(this.fileId, pageNumber, this.usePngImagesForHtmlBasedEngine,
this.embedImagesIntoHtmlForWordFiles,
this.instanceIdToken,
this.saveFontsInAllFormats,
function (response) {
this.setPageHtml(page, pageNumber, response.pageHtml, response.pageCss);
if (successCallback)
successCallback.call();
}.bind(this),
function (error) {
page.startedDownloadingPage = false;
this._onError(error);
}.bind(this),
this.locale
);
}
},
setPageHtml: function (page, pageNumber, pageHtml, pageCss) {
var css = pageCss;
if (!this.pageCssElement)
this.pageCssElement = $([]);
if (this.browserIsIE9OrLess) {
var firstStyle = this.pageCssElement.filter("style:first");
css = firstStyle.html();
firstStyle.remove();
css += pageCss;
}
var styleElement = $("<style type='text/css'>" + css + "</style>");
this.pageCssElement = this.pageCssElement.add(styleElement);
styleElement.appendTo("head");
var useTabsForPages = this.useTabsForPages();
if (useTabsForPages || useTabsForPages === null) { // null means no document loaded
pageHtml = pageHtml.replace(/^[\r\n\s]+|[\r\n\s]+$/g, "");
}
page.htmlContent(pageHtml);
var searchParameters = {
text: this.searchText,
isCaseSensitive: false,
searchForSeparateWords: this.searchForSeparateWords,
treatPhrasesInDoubleQuotesAsExact: this.treatPhrasesInDoubleQuotesAsExact,
pageNumber: pageNumber
};
if (this.useVirtualScrolling) {
page.parsedHtmlElement = $(pageHtml);
page.currentValue = pageHtml;
this.parseSearchParameters(page.parsedHtmlElement.not("style")[0], searchParameters);
}
page.searchText(searchParameters);
page.visible(true);
page.startedDownloadingPage = false;
this.markContentControls(pageNumber);
},
addPageCss: function (pageCss) {
var css = pageCss;
if (!this.pageCssElement)
this.pageCssElement = $([]);
if (this.browserIsIE9OrLess) {
var firstStyle = this.pageCssElement.filter("style:first");
css = firstStyle.html();
firstStyle.remove();
css += pageCss;
}
var styleElement = $("<style type='text/css'>" + css + "</style>");
this.pageCssElement = this.pageCssElement.add(styleElement);
styleElement.appendTo("head");
},
retrieveImageUrls: function (imageCount) {
var i;
var pageDimension, pageWidth;
if (this.shouldMinimumWidthBeUsed(this.pageWidth(), true))
pageWidth = this.minimumImageWidth;
else
pageWidth = this.pageWidth();
pageDimension = Math.floor(pageWidth) + "x";
this._model.retrieveImageUrls(this.fileId, this._sessionToken, imageCount, (this._mode == 'webComponent' ? Math.floor(pageWidth) : pageDimension),
this.watermarkText, this.watermarkColor, this.watermarkPosition, this.watermarkWidth,
this.ignoreDocumentAbsence,
this.useHtmlBasedEngine, this.supportPageRotation,
this.instanceIdToken,
function (response) {
var imageUrls;
if (response.imageUrls && typeof response.image_urls == "undefined")
imageUrls = response.imageUrls;
else
imageUrls = response.image_urls;
for (i = 0; i < imageCount; i++) {
this.pages()[i].url(imageUrls[i]);
this.loadImagesForVisiblePages();
}
}.bind(this),
function (error) {
this._onError(error);
}.bind(this),
this.locale);
},
_onError: function (error, fileId) {
this.inprogress(false);
var errorFunction = window.jerror || (window.jGDError && window.jGDError[this.instanceId]);
if (errorFunction)
errorFunction(error.Reason || "The document couldn't be loaded...", fileId);
},
_onDocumentLoadFailed: function (error, fileId) {
this.inprogress(false);
if (error.code == 'Unauthorized')
$(this).trigger('onDocumentPasswordRequired');
else {
this._onError(error, fileId);
this.documentSpace.trigger("documentLoadFailed.groupdocs");
}
},
_onDocumentLoadedBeforePdf2Xml: function (response) {
var self = this;
function callOnDocumentLoaded() {
self._onDocumentLoaded(response);
}
if (response.path && typeof response.guid == "undefined")
response.guid = response.path;
var options = {
userId: this.userId,
privateKey: this.userKey,
fileId: this.fileId,
guid: response.guid,
documentDescription: response.documentDescription,
callback: callOnDocumentLoaded,
setTextPositionsCalculationFinishedCallback: this._setTextPositionsCalculationFinished,
viewerThis: this
};
if (this.useJavaScriptDocumentDescription) {
options.synchronousWork = this.textSelectionSynchronousCalculation;
options.descForHtmlBasedEngine = (this.pageContentType == "html"
|| this.use_pdf == 'false');
this._pdf2XmlWrapper = new jGroupdocs.Pdf2JavaScriptWrapper(options);
this._onDocumentLoaded(response);
}
else {
if (this.use_pdf == 'false')
this._onDocumentLoaded(response);
else
this._pdf2XmlWrapper = new jSaaspose.Pdf2XmlWrapper(options);
}
},
_onDocumentLoaded: function (response) {
this.isDocumentLoaded = true;
if (this.useJavaScriptDocumentDescription) {
response.page_count = this._pdf2XmlWrapper.getPageCount();
}
else if (typeof response.page_count == "undefined" && response.documentDescription) {
var documentDescription = JSON.parse(response.documentDescription);
if (documentDescription.pages && typeof documentDescription.pages.length != "undefined")
response.page_count = documentDescription.pages.length;
// for compatibility with Comparison which does not use Pdf2JavaScriptWrapper
}
if (response.docType && typeof response.doc_type == "undefined")
response.doc_type = response.docType;
if (response.imageUrls && typeof response.image_urls == "undefined")
response.image_urls = response.imageUrls;
if (response.path && typeof response.guid == "undefined")
response.guid = response.path;
if (!response.page_size)
response.page_size = {};
$(this).trigger('onDocumentLoaded', response);
var self = this;
this._sessionToken = response.token;
this.docGuid = response.guid;
this.pageCount(response.page_count);
this.documentName(response.name);
this.docType(response.doc_type);
this.password(response.password);
this.matchesCount = 0;
$(this).trigger('getPagesCount', response.page_count);
if (this.variableHeightPageSupport) {
response.documentDescription = this._pdf2XmlWrapper.documentDescription;
}
var pages = null;
var pageSize = null;
var i;
var rotationFromServer;
var isTextDocument;
var scaleRatio;
if (this.supportListOfContentControls)
this.contentControls = this._pdf2XmlWrapper.getContentControls();
if (this.supportListOfBookmarks)
this.bookmarks = this._pdf2XmlWrapper.getBookmarks();
if (this.pageContentType == "image") {
if (this.use_pdf != 'false' || this.variableHeightPageSupport) {
pageSize = this._pdf2XmlWrapper.getPageSize();
if (this.variableHeightPageSupport) {
response.page_size.Width = pageSize.width;
response.page_size.Height = pageSize.height;
}
this.scale(this.pageImageWidth * (this.initialZoom / 100) / pageSize.width);
this.unscaledPageHeight = Number(pageSize.height);
this.unscaledPageWidth = Number(pageSize.width);
}
this.heightWidthRatio = parseFloat(response.page_size.Height / response.page_size.Width);
this.pageHeight(Math.round(this.pageImageWidth * this.heightWidthRatio * (this.initialZoom / 100)));
$(this).trigger('_onProcessPages', response);
}
else if (this.pageContentType == "html") {
this.watermarkScreenWidth = null;
this.zoom(100);
this.fileType = response.fileType;
this.urlForResourcesInHtml = response.urlForResourcesInHtml;
isTextDocument = (this.fileType == "Txt" || this.fileType == "Xml");
this.isHtmlDocument(this.fileType == "Html" || this.fileType == "Htm" || isTextDocument);
var isDocumentSinglePaged = (response.doc_type == "Cells" || this.isHtmlDocument());
this.useTabsForPages(isDocumentSinglePaged);
isDocumentSinglePaged |= (response.doc_type == "Image");
this.documentSpace.trigger("isDocumentSinglePaged.groupdocs", isDocumentSinglePaged);
this.alwaysShowLoadingSpinner(!isDocumentSinglePaged);
var browserIsChrome = $.browser.webkit && !!window.chrome;
var isChromium = window.chrome;
var vendorName = window.navigator.vendor;
var isOpera = window.navigator.userAgent.indexOf("OPR") > -1;
if (!!isChromium && vendorName === "Google Inc." && isOpera == false)
browserIsChrome = true;
this.browserIsChrome(browserIsChrome);
var pageCss = response.pageCss[0];
if (!pageCss)
pageCss = "";
if (this.pageCssElement)
this.pageCssElement.remove();
this.urlForImagesInHtml = response.urlForImagesInHtml;
this.urlForFontsInHtml = response.urlForFontsInHtml;
this.pageCssElement = $([]);
this.preloadedPages = { html: response.pageHtml, css: response.pageCss };
var firstPageHtml = response.pageHtml[0];
var firstPage = this.pages()[0];
pages = this._pdf2XmlWrapper.documentDescription.pages;
this.autoHeight(this.useTabsForPages());
var element;
if (this.useTabsForPages()) {
this.pageCount(1);
if (this.isHtmlDocument()) {
var bodyContents;
if (isTextDocument) {
bodyContents = "<div class='text_document_wrapper'>" + firstPageHtml + "</div>";
}
else {
var headContents = this.getHtmlElementContents(firstPageHtml, "head");
if (headContents) {
var styleElementContents = this.getHtmlElements(headContents, "style");
var linkElementContents = this.getHtmlElementAttributess(headContents, "link");
if (linkElementContents != null) {
this.linkElementsToLoad = 0;
for (i = 0; i < linkElementContents.length; i++) {
element = $(linkElementContents[i]);
var rel = element.attr("rel");
if (rel == "stylesheet") {
this.linkElementsToLoad++;
var uri = element.attr("href");
$.get(uri,
function (response) {
var styleElement = $("<style type='text/css'>" + response + "</style>");
self.pageCssElement = self.pageCssElement.add(styleElement);
styleElement.prependTo("head");
self.linkElementsToLoad--;
if (self.linkElementsToLoad == 0) {
self.autoHeight(true);
self._calculatePageSizeFromDOM();
self.adjustInitialZoom();
}
})
.fail(function () {
self.linkElementsToLoad--;
if (self.linkElementsToLoad == 0) {
self.autoHeight(true);
self._calculatePageSizeFromDOM();
self.adjustInitialZoom();
}
});
}
}
}
if (styleElementContents) {
for (i = 0; i < styleElementContents.length; i++) {
var css = styleElementContents[i];
pageCss += css;
}
}
}
bodyContents = this.getPageBodyContentsWithReplace(firstPageHtml);
}
var bodyContentsElement = $(bodyContents);
bodyContentsElement.find("script").remove();
bodyContentsElement.addClass('html_document_wrapper');
firstPageHtml = bodyContentsElement[0].outerHTML;
var fontSizeStyle = ".grpdx .ie .doc-page .html_page_contents > div {font-size:1em;}";
pageCss += fontSizeStyle;
}
}
else {
pageSize = this._pdf2XmlWrapper.getPageSize();
firstPage.prop(pages[0].h / pages[0].w);
scaleRatio = this.getScaleRatioForPage(pageSize.width, pageSize.height, pages[0].w, pages[0].h);
firstPage.heightRatio(scaleRatio);
this.documentSpace.css("background-color", "inherit");
}
element = $("<style>" + pageCss + "</style>");
this.pageCssElement = this.pageCssElement.add(element);
element.appendTo("head");
var sharedCss = response.sharedCss;
if (sharedCss) {
var sharedElement = $("<style>" + sharedCss + "</style>");
this.pageCssElement = this.pageCssElement.add(sharedElement);
sharedElement.appendTo("head");
}
this.calculatePointToPixelRatio();
var htmlPageContents = this.documentSpace.find(".html_page_contents:first");
firstPage.htmlContent(firstPageHtml);
firstPage.visible(true);
this.clearContentControls();
this.markContentControls(0);
this.tabs.removeAll();
if (this.useTabsForPages()) {
var sheets = this._pdf2XmlWrapper.documentDescription.sheets;
if (sheets) {
for (i = 0; i < sheets.length; i++) {
this.tabs.push({
name: sheets[i].name,
visible: ko.observable(false),
htmlContent: ko.observable(""),
searchText: ko.observable(null)
});
}
}
this.activeTab(0);
this.documentSpace.css("background-color", "white");
}
if (this.useTabsForPages() && this.tabs().length > 0)
this.documentSpace.addClass("doc_viewer_tabs");
else
this.documentSpace.removeClass("doc_viewer_tabs");
var pageElement = htmlPageContents.children("div,table,img");
var pageElementWidth;
if (this.useTabsForPages()) {
pageElementWidth = pageElement.width();
var pageElementHeight = pageElement.height();
firstPage.prop(pageElementHeight / pageElementWidth);
pageSize = { width: pageElementWidth, height: pageElementHeight };
firstPage.heightRatio(1);
}
if (this.supportPageRotation) {
if (pages)
rotationFromServer = pages[0].rotation;
else
rotationFromServer = 0;
if (typeof rotationFromServer == "undefined")
rotationFromServer = 0;
this.applyPageRotationInBrowser(0, firstPage, rotationFromServer);
}
this.imageHorizontalMargin = 7;
response.page_size.Width = pageSize.width;
response.page_size.Height = pageSize.height;
var pageWidthFromServer = pageSize.width;
var onlyImageInHtml = false;
var pageElementChildren = pageElement.children();
if (pageElementChildren.length == 1 && pageElementChildren.filter("img").length == 1)
onlyImageInHtml = true;
var oldWidth = null;
if (!onlyImageInHtml && !this.useTabsForPages()) {
oldWidth = pageElement.css("width");
pageElement.css("width", pageWidthFromServer + "pt");
}
if (this.isHtmlDocument())
pageElementWidth = this.getFitWidth();
else
pageElementWidth = pageElement.width();
this.heightWidthRatio = parseFloat(response.page_size.Height / response.page_size.Width);
if (!this.useTabsForPages() || !this.supportPageRotation || firstPage.rotation % 180 == 0)
this.pageWidth(pageElementWidth);
if (oldWidth !== null && typeof oldWidth != "undefined")
pageElement.css("width", oldWidth);
this.pageHeight(Math.round(this.pageWidth() * this.heightWidthRatio));
this.initialWidth = this.pageWidth();
}
var pageCount = this.pageCount();
if (!response.lic && pageCount > 3)
pageCount = 3;
var pagesNotObservable = [];
var pageDescription;
if (this.pageContentType == "image") {
//this.pages.removeAll();
var pageImageUrl, pageDescriptionCount;
if (this.variableHeightPageSupport) {
this.serverPages = pages = this._pdf2XmlWrapper.documentDescription.pages;
pageDescriptionCount = this._pdf2XmlWrapper.getPageCount();
//pageDescriptionCount = pages.length;
}
for (i = 0; i < pageCount; i++) {
if (i < response.image_urls.length)
pageImageUrl = response.image_urls[i];
else
pageImageUrl = "";
pageDescription = {
number: i + 1,
visible: ko.observable(false),
url: ko.observable(pageImageUrl)
};
if (this.variableHeightPageSupport) {
if (i < pageDescriptionCount && pages)
pageDescription.prop = ko.observable(pages[i].h / pages[i].w);
else
pageDescription.prop = ko.observable(this.pageHeight() / this.pageWidth());
}
if (this.supportPageRotation) {
rotationFromServer = this.serverPages[i].rotation;
if (typeof rotationFromServer == "undefined")
rotationFromServer = 0;
pageDescription.rotation = ko.observable(rotationFromServer);
this.applyPageRotationInBrowser(i, pageDescription, rotationFromServer);
}
if (this.useVirtualScrolling) {
pageDescription.left = 0;
pageDescription.top = ko.observable(0);
}
pagesNotObservable.push(pageDescription);
}
}
else if (this.pageContentType == "html") {
this.serverPages = pages = this._pdf2XmlWrapper.documentDescription.pages;
//this.pages.splice(1, this.pages().length - 1);
//var documentHeight = 0;
//var pageTop = 0;
pageWidth = this.pageWidth();
pageDescription = this.pages()[0];
//var layout = this.layout();
//if (layout != this.Layouts.TwoPagesInRow)
//    pageTop += pageWidth * pageDescription.prop();
//documentHeight += pageWidth * pageDescription.prop();
pagesNotObservable.push(pageDescription);
var proportion;
//var cssForAllPages = "";
for (i = 1; i < pageCount; i++) {
scaleRatio = this.getScaleRatioForPage(pageSize.width, pageSize.height, pages[i].w, pages[i].h);
proportion = pages[i].h / pages[i].w;
pageDescription = {
number: i + 1,
visible: ko.observable(false),
htmlContent: ko.observable(""),
prop: ko.observable(proportion),
heightRatio: ko.observable(scaleRatio),
searchText: ko.observable(null)
};
//var pageHtml = this.preloadedPages && this.preloadedPages.html[i];
//if (pageHtml) {
//    pageDescription.htmlContent(pageHtml);
//    if (this.preloadedPages.css[i])
//        cssForAllPages += this.preloadedPages.css[i];
//    pageDescription.visible(true);
//}
if (this.supportPageRotation) {
rotationFromServer = this.serverPages[i].rotation;
if (typeof rotationFromServer == "undefined")
rotationFromServer = 0;
pageDescription.rotation = ko.observable(rotationFromServer);
this.applyPageRotationInBrowser(i, pageDescription, rotationFromServer);
}
if (this.useVirtualScrolling) {
pageDescription.left = 0;
pageDescription.top = ko.observable(0);
}
//    if (layout == this.Layouts.OnePageInRow
//        || (layout == this.Layouts.TwoPagesInRow && i % 2 == 1)
//        || (layout == this.Layouts.CoverThenTwoPagesInRow && i % 2 == 0)) {
//        pageTop += pageWidth * proportion;
//        documentHeight = pageTop;
//    }
//    else
//        documentHeight = pageTop + pageHeight;
//    //pageTop += pageWidth * proportion * scaleRatio;
//}
pagesNotObservable.push(pageDescription);
}
//if (this.useVirtualScrolling)
//    this.documentHeight(documentHeight);
if (isDocumentSinglePaged)
response.page_count = 0; // for thumbnails after rotation
this.documentSpace.trigger('_onProcessPages', [response, pagesNotObservable, this.getDocumentPageHtml, this, this.pointToPixelRatio, this.docViewerId]);
}
this.pages(pagesNotObservable);
this.calculatePagePositionsForVirtualMode();
this._firstPage = this.documentSpace.find("#" + this.pagePrefix + "1");
if (this.pages().length > 0 && this._firstPage.length == 0 && !this.useVirtualScrolling) // viewer destroyed while loading document
return;
$(this).trigger('onProcessPages', [this.docGuid]);
this.inprogress(false);
if (this.pageContentType == "image") {
this.recalculatePageLeft();
}
//var hCount = Math.floor(this.pagesContainerElement.width() / this._firstPage.width());
var hCount = Math.floor(this.pagesContainerElement.width() / this.pageWidth());
if (hCount == 0)
hCount = 1;
if (this.layout() == this.Layouts.OnePageInRow)
hCount = 1;
if (this._pdf2XmlWrapper && this._pdf2XmlWrapper._setTextPositionsCalculationFinished)
this._isTextPositionsCalculationFinished = false;
var scale = this.scale();
this._dvselectable = this.pagesContainerElement.dvselectable({
txtarea: this.selectionContent,
pdf2XmlWrapper: this._pdf2XmlWrapper,
startNumbers: this.getVisiblePagesNumbers(),
pagesCount: this.pageCount(),
proportion: scale,
pageHeight: this.getPageHeight(),
horizontalPageCount: hCount,
docSpace: this.documentSpace,
pagePrefix: this.pagePrefix,
searchPartialWords: this.searchPartialWords,
storeAnnotationCoordinatesRelativeToPages: this.storeAnnotationCoordinatesRelativeToPages,
initializeStorageOnly: this.pageContentType == "html",
preventTouchEventsBubbling: this.preventTouchEventsBubbling,
highlightColor: this.options.highlightColor,
useVirtualScrolling: this.useVirtualScrolling,
pageLocations: (this.useVirtualScrolling ? this.pages() : null),
initStorageOnMouseStart: this.initStorageOnMouseStart
});
this._dvselectable.dvselectable("setVisiblePagesNumbers", this.getVisiblePagesNumbers());
if (!this.docWasLoadedInViewer && (this.usePageNumberInUrlHash === undefined || this.usePageNumberInUrlHash == true)) {
var firstPageLocation = location.pathname;
if (location.hash.substring(1, this.hashPagePrefix.length + 1) != this.hashPagePrefix)
this.setPage(1);
Sammy(function () {
this.get(/\#page(.*)/i, openPath);
this.get(firstPageLocation, openFirstPage);
function openFirstPage() {
if (self.pageInd() != 1)
self.setPage(1);
}
function openPath() {
if (!self.changedUrlHash) {
if (this.params.splat.length == 0 || this.params.splat[0].length == 0) {
}
else {
var hashString = this.params.splat[0];
//hashString = hashString.substring(1);
var newPageIndex = Number(hashString);
if (isNaN(newPageIndex))
newPageIndex = 1;
if (newPageIndex > self.pageCount())
newPageIndex = self.pageCount();
if (newPageIndex < 1)
newPageIndex = 1;
self.setPage(newPageIndex);
}
}
}
}).run();
}
else {
this.setPage(1);
}
if (!this.zoomToFitHeight)
this.loadImagesForVisiblePages(true);
this.adjustInitialZoom();
this.docWasLoadedInViewer = true;
// get a list of document hyperlinks from the server
if (this.pageContentType == "image" && this._mode != "webComponent" && this._mode != "annotatedDocument") {
this._loadHyperlinks();
}
if (this.preloadPagesOnBrowserSide) {
var preloadPagesCount = this.preloadPagesCount;
if (preloadPagesCount === null || preloadPagesCount > this.pageCount())
preloadPagesCount = this.pageCount();
this.loadImagesForPages(1, preloadPagesCount);
}
$(this).trigger('onScrollDocView', { pi: 1, direction: "up", position: 0 });
$(this).trigger("onDocumentLoadComplete", [response, this._pdf2XmlWrapper]);
if (this._isTextPositionsCalculationFinished)
this.raiseDocumentLoadCompletedEvent();
},
_onDocumentHyperlinksLoaded: function (response) {
if (!response || !response.links) {
this.hyperlinks.removeAll();
return;
}
var links = [];
var self = this;
var selectable = this.getSelectableInstance();
$.each(response.links, function () {
var l = {
url: this.Url,
pageNumber: this.PageNumber,
targetPage: this.TargetPage,
rect: new jSaaspose.Rect(this.Bounds.X, this.Bounds.Y, this.Bounds.X + this.Bounds.Width, this.Bounds.Y + this.Bounds.Height)
};
l.frame = ko.observable(selectable != null ? selectable.convertPageAndRectToScreenCoordinates(l.pageNumber, l.rect) : l.rect);
/*var frame = l.rect.clone().scale(self.scale());
if (frame.top() < 0)
frame.setTop(0);
frame.add(selectable.pages[l.pageNumber].rect.topLeft);
return frame;
}, self);*/
links.push(l);
});
this.hyperlinks(links);
},
_loadHyperlinks: function () {
if (this.options.showHyperlinks == true) {
this._model.loadHyperlinks(
this.fileId,
this._onDocumentHyperlinksLoaded.bind(this),
function (error) {
});
}
},
_refreshHyperlinkFrames: function () {
var selectable = this.getSelectableInstance();
$.each(this.hyperlinks(), function () {
this.frame(selectable != null ? selectable.convertPageAndRectToScreenCoordinates(this.pageNumber, this.rect) : this.rect);
});
},
setPageWidth: function (val) {
this.pageImageWidth = val;
},
setContainerWidth: function (containerWidth) {
this.viewerWidth = containerWidth;
},
getFitWidth: function () {
var viewerWidth;
if (this.viewerWidth)
viewerWidth = this.viewerWidth;
else
viewerWidth = this.documentSpace.width();
var scrollbarWidth = this.getScrollbarWidth();
var fittingWidth = viewerWidth - scrollbarWidth - 2 * (this.imageHorizontalMargin + 1);
if (!this.useTabsForPages()) {
var layout = this.layout();
if (layout == this.Layouts.TwoPagesInRow
|| layout == this.Layouts.CoverThenTwoPagesInRow)
fittingWidth = fittingWidth / 2;
}
return fittingWidth;
},
getFitWidthZoom: function () {
return this.getFitWidth() / this.initialWidth * 100;
},
setContainerHeight: function (containerHeight) {
this.viewerHeight = containerHeight;
},
getViewerHeight: function () {
var viewerHeight;
if (this.viewerHeight)
viewerHeight = this.viewerHeight;
else
viewerHeight = this.documentSpace.parent().height();
return viewerHeight;
},
getFitHeightZoom: function () {
var viewerHeight = this.getViewerHeight();
return (viewerHeight - (this.imageVerticalMargin + 2)) / Math.round(this.initialWidth * this.heightWidthRatio) * 100;
//return viewerHeight / Math.round(this.pageImageWidth * this.heightWidthRatio) * 100;
},
getScrollbarWidth: function () {
if (this.scrollbarWidth == null) {
// Create the measurement node
var scrollDivJquery = $("<div/>").css("width", "100px").css("height", "100px")
.css("overflow", "scroll").css("position", "absolute").css("top", "-9999px");
var scrollDiv = scrollDivJquery[0];
document.body.appendChild(scrollDiv);
// Get the scrollbar width
this.scrollbarWidth = scrollDiv.offsetWidth - scrollDiv.clientWidth;
// Delete the DIV
document.body.removeChild(scrollDiv);
}
return this.scrollbarWidth;
},
getPageHeight: function () {
return this.unscaledPageHeight * this.scale();
},
getSelectable: function () {
return this._dvselectable;
},
_onPropertiesLoaded: function (response) {
$(this).trigger('onDocumentLoaded', { fileId: this.fileId, response: response });
},
getFileId: function () {
return this.fileId;
},
ScrollDocView: function (item, e) {
var isSetCalled = this.isSetCalled;
this.isSetCalled = false;
if (isSetCalled)
return;
if (this.useTabsForPages())
return;
//var direction;
var pageIndex = null;
var panelHeight = this.documentSpace.height();
var st = $(e.target).scrollTop();
$(this).trigger('onBeforeScrollDocView', { position: st });
if (this.variableHeightPageSupport) {
var selectable = this.getSelectableInstance();
if (selectable == null)
return null;
selectable.initStorage();
var pageLocations = selectable.pageLocations;
var pageImageTop, pageImageBottom;
var pages = this.pages();
var visiblePageNumbers;
visiblePageNumbers = this.getVisiblePagesNumbers();
var documentSpaceHeight = this.documentSpace.height();
var nearestPageNumber = null, maxPartWhichIntersects = null;
var topOfIntersection, bottomOfIntersection, lengthOfIntersection, partWhichIntersects;
for (var i = visiblePageNumbers.start - 1; i <= visiblePageNumbers.end - 1; i++) {
if (this.useVirtualScrolling)
pageImageTop = pages[i].top();
else
pageImageTop = pageLocations[i].y;
pageHeight = pages[i].prop() * this.pageWidth();
pageImageBottom = Math.floor(pageImageTop + pageHeight);
topOfIntersection = Math.max(pageImageTop, st);
bottomOfIntersection = Math.min(pageImageBottom, st + documentSpaceHeight);
lengthOfIntersection = bottomOfIntersection - topOfIntersection;
partWhichIntersects = lengthOfIntersection / pageHeight;
if (maxPartWhichIntersects == null || partWhichIntersects > maxPartWhichIntersects) {
maxPartWhichIntersects = partWhichIntersects;
nearestPageNumber = i;
}
}
pageIndex = nearestPageNumber + 1;
}
else {
if (this._firstPage != null) {
pageIndex = (st + panelHeight / 2) / (this._firstPage.outerHeight(true));
var hCount = Math.floor(this.pagesContainerElement.width() / this._firstPage.width());
if (hCount == 0)
hCount = 1;
if (this.layout() == this.Layouts.OnePageInRow)
hCount = 1;
pageIndex = (pageIndex >> 0);
var totalPageCount = this.pageCount();
if (pageIndex != totalPageCount)
pageIndex = pageIndex + 1;
pageIndex = (pageIndex - 1) * hCount + 1;
if (pageIndex > totalPageCount)
pageIndex = totalPageCount;
}
}
if (pageIndex !== null) {
this.pageInd(pageIndex);
this.setPageNumerInUrlHash(pageIndex);
$(this).trigger('onScrollDocView', { pi: pageIndex, position: st });
this.documentSpace.trigger("documentScrolledToPage.groupdocs", [pageIndex]);
}
},
ScrollDocViewEnd: function (item, e) {
if (this.useTabsForPages())
return;
this.isSetCalled = false;
this.scrollPosition = [$(e.target).scrollLeft(), $(e.target).scrollTop()];
var numbers = this.loadImagesForVisiblePages();
if (this._dvselectable) {
$(this._dvselectable).dvselectable("setVisiblePagesNumbers", numbers);
}
$(this).trigger('onDocumentPageSet', [this.pageInd()]);
this.documentSpace.trigger("documentScrolledToPage.groupdocs", [this.pageInd()]);
},
getVisiblePagesNumbers: function () {
if (!this.isDocumentLoaded)
return null;
if (this.useTabsForPages()) {
return { start: 1, end: 1 };
}
var start = null;
var end = null;
var scrollTop = this.documentSpace.scrollTop();
var pageHeight;
var startIndex = null;
var documentSpaceHeight = this.documentSpace.height();
if (this.variableHeightPageSupport) {
var selectable = this.getSelectableInstance();
if (selectable == null && !this.useVirtualScrolling)
return null;
var pages = this.pages();
var pageLocations;
var pageCount;
if (this.useVirtualScrolling)
pageCount = pages.length;
else {
pageLocations = selectable.pageLocations;
if (pageLocations.length != pages.length)
return null;
pageCount = pageLocations.length;
}
var pageImageTop, pageImageBottom;
for (var i = 0; i < pageCount; i++) {
if (this.useVirtualScrolling)
pageImageTop = pages[i].top();
else
pageImageTop = pageLocations[i].y;
pageHeight = pages[i].prop() * this.pageWidth();
pageImageBottom = pageImageTop + pageHeight;
if ((pageImageTop >= scrollTop && pageImageTop <= scrollTop + documentSpaceHeight) ||
(pageImageBottom >= scrollTop && pageImageBottom <= scrollTop + documentSpaceHeight) ||
(pageImageTop <= scrollTop && pageImageBottom >= scrollTop + documentSpaceHeight)) {
if (start === null)
start = i + 1;
else
end = i + 1;
}
}
if (end === null)
end = start;
}
else {
if (this._firstPage != null) {
pageHeight = this._firstPage.outerHeight(true); // div height
var pageWidth = this._firstPage.outerWidth(true); // div width
//var scrollTop = this.scrollPosition[1], //scroll top
var dsW = this.pagesContainerElement.width();
startIndex = Math.floor(scrollTop / pageHeight) + 1;
var endIndex = Math.floor((scrollTop + documentSpaceHeight) / pageHeight) + 1;
var hCountToShow = Math.floor(dsW / pageWidth);
if (hCountToShow == 0)
hCountToShow = 1;
if (this.layout() == this.Layouts.OnePageInRow)
hCountToShow = 1;
start = startIndex != 1 ? (startIndex - 1) * hCountToShow + 1 : 1;
end = endIndex * hCountToShow <= this.pageCount() ? endIndex * hCountToShow : this.pageCount();
}
}
return { start: start, end: end };
},
loadImagesForVisiblePages: function (forceLoading) {
var numbers = this.getVisiblePagesNumbers();
if (numbers != null) {
var start = numbers.start;
var end = numbers.end;
if (start !== null && end !== null) {
this.loadImagesForPages(start, end, forceLoading);
if (this.useVirtualScrolling) {
this.firstVisiblePageForVirtualMode(numbers.start - 1);
this.lastVisiblePageForVirtualMode(numbers.end - 1);
}
}
}
return numbers;
},
loadImagesForPages: function (start, end, forceLoading) {
var pages = this.pages();
var cssForAllPages = "";
var page;
var isPageVisible;
if (pages.length < end) end = pages.length;
for (var i = start; i <= end; i++) {
page = pages[i - 1];
isPageVisible = page.visible();
if (isPageVisible)
this.markContentControls(i - 1);
if (this.pageContentType == "image") {
this.triggerImageLoadedEvent(i);
if (this.supportPageRotation && forceLoading) {
this.addSuffixToImageUrl(page);
}
}
else if (this.pageContentType == "html") {
if (!isPageVisible) {
this.getDocumentPageHtml(i - 1);
}
}
page.visible(true);
}
if (this.pageContentType == "html" && cssForAllPages != "")
this.addPageCss(cssForAllPages);
//for (var i = start; i <= end; i++) {
//    page = pages[i - 1];
//    page.visible(true);
//}
},
setPage: function (index) {
this.isSetCalled = true;
var newPageIndex = Number(index);
if (isNaN(newPageIndex) || newPageIndex < 1)
newPageIndex = 1;
this.pageInd(newPageIndex);
var pageTop;
if (this.variableHeightPageSupport) {
if (this.useVirtualScrolling) {
pageTop = this.pages()[newPageIndex - 1].top();
}
else {
var selectable = this.getSelectableInstance();
if (selectable != null) {
if (selectable.pageLocations && selectable.pageLocations.length > 0) {
var pageImageTop = selectable.pageLocations[newPageIndex - 1].y;
pageTop = pageImageTop;
}
}
}
}
else {
var hCount = Math.floor(this.pagesContainerElement.width() / this._firstPage.width());
if (hCount == 0)
hCount = 1;
if (this.layout() == this.Layouts.OnePageInRow)
hCount = 1;
var selIndex = Math.ceil(newPageIndex / hCount) - 1;
pageTop = selIndex * this._firstPage.outerHeight(true);
}
var oldScrollTop = this.documentSpace.scrollTop();
this.documentSpace.scrollTop(pageTop);
if (this.documentSpace.scrollTop() == oldScrollTop) {
this.isSetCalled = false;
}
$(this).trigger('onDocViewScrollPositionSet', { position: pageTop });
var page = this.pages()[newPageIndex - 1];
if (this.pageContentType == "image") {
this.triggerImageLoadedEvent(newPageIndex);
page.visible(true);
}
else if (this.pageContentType == "html") {
if (!page.visible()) {
this.getDocumentPageHtml(newPageIndex - 1);
}
}
//this.isSetCalled = false;
this.setPageNumerInUrlHash(newPageIndex);
$(this).trigger('onDocumentPageSet', [newPageIndex]);
this.documentSpace.trigger("documentPageSet.groupdocs", newPageIndex);
},
triggerImageLoadedEvent: function (pageIndex) {
if ($.browser.msie) {
if (!this.pages()[pageIndex - 1].visible()) {
$("img#img-" + pageIndex).load(function () {
$(this).trigger("onPageImageLoaded");
});
}
}
},
setZoom: function (value) {
this.zoom(value);
this.loadPagesZoomed();
this.clearContentControls();
if (this.pageContentType == "image") {
if (this._pdf2XmlWrapper) {
var pageSize = this._pdf2XmlWrapper.getPageSize();
this.scale(this.pageImageWidth / pageSize.width * value / 100);
}
this._dvselectable.dvselectable("changeSelectedRowsStyle", this.scale());
this.reInitSelectable();
if (this.useVirtualScrolling) {
this.getSelectableInstance().recalculateSearchPositions(this.scale());
this.highlightSearch();
}
this.recalculatePageLeft();
this.setPage(this.pageInd());
if (this.shouldMinimumWidthBeUsed(this.pageWidth(), true))
this.loadImagesForVisiblePages();
if (this.options.showHyperlinks) {
this._refreshHyperlinkFrames();
}
}
else if (this.pageContentType == "html") {
this.reInitSelectable();
this.setPage(this.pageInd());
this.loadImagesForVisiblePages();
this.reflowPagesInChrome(true);
}
},
loadPagesZoomed: function () {
if (this.useTabsForPages()) {
this._calculatePageSizeFromDOM();
return;
}
var newWidth = Math.round(this.initialWidth * (this.zoom()) / 100);
var newHeight = Math.round(newWidth * this.heightWidthRatio);
if (newWidth != this.pageWidth() || newHeight != this.pageHeight()) {
this.pagesDimension = Math.floor(newWidth) + 'x';
this.pageWidth(newWidth);
this.pageHeight(newHeight);
if (!this.useTabsForPages()) {
this.calculatePagePositionsForVirtualMode();
}
if (this.pageContentType == "image") {
var pageCount = this.pageCount();
if (!this.shouldMinimumWidthBeUsed(newWidth, true))
this.retrieveImageUrls(pageCount);
}
}
},
performSearch: function (value, isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact, useAccentInsensitiveSearch) {
if (this.pageContentType == "image") {
var selectable = this.getSelectableInstance();
if (selectable != null) {
var searchCountItem = selectable.performSearch(value, this.scale(), isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact, useAccentInsensitiveSearch);
$(this).trigger('onSearchPerformed', [searchCountItem]);
}
}
else {
this.searchText = value;
this.searchForSeparateWords = searchForSeparateWords;
this.treatPhrasesInDoubleQuotesAsExact = treatPhrasesInDoubleQuotesAsExact;
var pages = this.pages();
var page;
if (this.loadAllPagesOnSearch)
this.loadImagesForPages(1, pages.length);
for (var i = 0; i < pages.length; i++) {
page = pages[i];
if (page.visible()) {
var searchParameters = {
text: value,
isCaseSensitive: isCaseSensitive,
searchForSeparateWords: searchForSeparateWords,
treatPhrasesInDoubleQuotesAsExact: treatPhrasesInDoubleQuotesAsExact,
pageNumber: i
};
page.searchText(searchParameters);
}
}
}
},
searchHtmlElement: function (node, nodeName, className, words, wordsWithAccentedChars,
searchForSeparateWords, isCaseSensitive, fullWordsOnly, pageNumber) {
nodeName = nodeName || this.htmlSearchHighlightElement;
var totalWordCount;
var pattern, currentNodeMatchCount = 0;
var match = null;
var nodeText = null;
var regexp;
if (node.nodeType === 3) {
if (words) {
totalWordCount = words.length;
var trimmedText = node.data.replace(/[\r\n\s]+$/g, "");
var separatorsRegexString = "[" + this.searchSeparatorsList + "]";
var wordStartSeparatorsRegexString;
var wordEndSeparatorsRegexString;
var reservedSymbolsInEndRegExp = /[\-[\]{}()*+?\\^|\s.,:;+"]+$/g;
var currentWord, currentWordWithAccentedChars;
var index, length;
var highlightElementName;
var matchNum;
var previousMatchPosition = -1, matchLength = 0, previousMatchEndPosition = 0;
trimmedText = trimmedText.replace(reservedSymbolsInEndRegExp, "");
if (trimmedText.length == 0)
return 0;
if (searchForSeparateWords && !fullWordsOnly) {
var searchMatches = new Array();
for (var wordNum = 0; wordNum < words.length; wordNum++) {
currentWord = words[wordNum];
currentWordWithAccentedChars = wordsWithAccentedChars[wordNum];
pattern = currentWordWithAccentedChars;
length = pattern.length;
nodeText = node.data;
if (!isCaseSensitive) {
pattern = pattern.toLocaleLowerCase();
nodeText = nodeText.toLocaleLowerCase();
}
previousMatchEndPosition = 0;
do {
index = nodeText.indexOf(pattern, previousMatchEndPosition);
if (index != -1) {
searchMatches.push({ index: index, length: length });
previousMatchEndPosition = index + length;
}
} while (index != -1);
}
searchMatches.sort(function (match1, match2) {
return match2.index - match1.index;
});
var containingMatches = new Array();
// remove overlapping search hits but keep one of two hits overlapping each other
searchMatches = searchMatches.filter(function (match, index) {
return !searchMatches.some(function (innerMatch, innerIndex) {
var isContainedInAnother = innerIndex != index &&
(match.index >= innerMatch.index && match.index < innerMatch.index + innerMatch.length)
|| (match.index + match.length > innerMatch.index && match.index + match.length < innerMatch.index + innerMatch.length);
if (isContainedInAnother) {
if (containingMatches.indexOf(match) != -1)
return false;
containingMatches.push(innerMatch);
}
return isContainedInAnother;
});
});
var newNodesCreated = 0;
for (matchNum = 0; matchNum < searchMatches.length; matchNum++) {
highlightElementName = "search_highlight" + this.matchesCount.toString();
this.matchesCount++;
newNodesCreated += this.highlightOneNode(node, searchMatches[matchNum].index, searchMatches[matchNum].length, highlightElementName, className, pageNumber);
}
return newNodesCreated;
}
var isFirstWord, isLastWord;
var foundFirstWordsButDidNotFindOthers;
do {
currentWord = words[this.currentWordCounter];
currentWordWithAccentedChars = wordsWithAccentedChars[this.currentWordCounter];
isFirstWord = (this.currentWordCounter == 0);
isLastWord = (this.currentWordCounter == totalWordCount - 1);
if (isFirstWord && !fullWordsOnly) {
wordStartSeparatorsRegexString = "";
}
else {
wordStartSeparatorsRegexString = "(?:" + separatorsRegexString + "|^)+";
}
if (isLastWord && !fullWordsOnly) {
wordEndSeparatorsRegexString = "";
}
else {
wordEndSeparatorsRegexString = "(?:" + separatorsRegexString + "|$)+";
}
pattern = wordStartSeparatorsRegexString + "(" + currentWordWithAccentedChars + wordEndSeparatorsRegexString + ")";
nodeText = node.data;
nodeText = nodeText.substr(previousMatchEndPosition, nodeText.length - previousMatchEndPosition);
if ((this.matchedNodsCount > 0 && previousMatchPosition == -1) || previousMatchPosition != -1) // if searching a new <span> or not first word inside first span then search from beginning of string
pattern = "^" + pattern;
regexp = new RegExp(pattern, isCaseSensitive ? "" : "i");
foundFirstWordsButDidNotFindOthers = false;
match = nodeText.match(regexp);
if (match) {
if (previousMatchPosition == -1)
this.matchedNodsCount++;
currentNodeMatchCount++;
this.matchedNods.push(node);
index = previousMatchEndPosition + match.index;
length = match[0].length;
if (isFirstWord) {
index = previousMatchEndPosition + nodeText.indexOf(match[1], match.index);
length = match[1].length;
}
if (isLastWord && !this.useAccentInsensitiveSearch) {
var word = words[this.currentWordCounter];
var nodeTextToSearchIn = nodeText;
if (!isCaseSensitive) {
word = word.toLowerCase();
nodeTextToSearchIn = nodeTextToSearchIn.toLowerCase();
}
var wordIndex = previousMatchEndPosition + nodeTextToSearchIn.indexOf(word, match.index);
length = word.length + wordIndex - index;
}
this.searchMatches.push({ index: index, length: length });
previousMatchPosition = previousMatchEndPosition + match.index;
matchLength = match[0].length;
previousMatchEndPosition = previousMatchPosition + matchLength;
this.currentWordCounter++;
if (this.currentWordCounter >= totalWordCount) {
highlightElementName = "search_highlight" + this.matchesCount.toString();
for (matchNum = totalWordCount - 1; matchNum >= 0; matchNum--)
this.highlightOneNode(this.matchedNods[matchNum], this.searchMatches[matchNum].index, this.searchMatches[matchNum].length, highlightElementName, className, pageNumber);
this.currentWordCounter = 0;
this.matchedNods = [];
this.searchMatches = [];
this.matchedNodsCount = 0;
this.matchesCount++;
return currentNodeMatchCount;
}
}
else {
this.matchedNods = [];
this.searchMatches = [];
if (this.currentWordCounter > 0) {
// found first word or words (on previous step) inside this <span/> but failed to find others
previousMatchPosition = -1;
this.matchedNodsCount = 0;
foundFirstWordsButDidNotFindOthers = true;
}
this.currentWordCounter = 0;
}
} while ((match && previousMatchEndPosition < trimmedText.length) || foundFirstWordsButDidNotFindOthers);
if (!match)
this.matchedNodsCount = 0;
return 0;
}
}
else if ((node.nodeType === 1 && node.childNodes) && // only element nodes that have children
!/(script|style)/i.test(node.tagName) && // ignore script and style nodes
!(node.tagName === nodeName.toUpperCase() && node.className === className)) { // skip if already highlighted
var startNodeNum = 0;
//var endNodeNum = node.childNodes.length;
var i;
for (i = startNodeNum; i < node.childNodes.length; i++) {
i += this.searchHtmlElement(node.childNodes[i], nodeName, className, words, wordsWithAccentedChars,
searchForSeparateWords, isCaseSensitive, fullWordsOnly, pageNumber);
}
}
return 0;
},
highlightOneNode: function (node, matchIndex, matchLength, highlightElementName, className, pageNumber) {
var isSvg = false;
var nodeJquery = $(node);
var highlight, nodeName;
if (nodeJquery.is("tspan") || nodeJquery.parent().is("tspan")) {
isSvg = true;
nodeName = this.htmlSearchHighlightSvgElement;
var xmlns = "http://www.w3.org/2000/svg";
highlight = document.createElementNS(xmlns, nodeName);
highlight.setAttribute("class", className || this.htmlSearchHighlightClassName);
}
else {
nodeName = this.htmlSearchHighlightElement;
highlight = document.createElement(nodeName);
highlight.className = className || this.htmlSearchHighlightClassName;
}
var highlightJquery = $(highlight);
if (highlightElementName)
highlightJquery.attr("name", highlightElementName);
highlightJquery.attr("data-page-num", pageNumber.toString());
var newNodesCreated = 0;
var wordNode;
if (matchIndex == 0) {
wordNode = node;
}
else {
wordNode = node.splitText(matchIndex);
newNodesCreated++;
}
if (wordNode.textContent.length > matchLength) {
newNodesCreated++;
wordNode.splitText(matchLength);
}
var wordClone = wordNode.cloneNode(true);
highlight.appendChild(wordClone);
wordNode.parentNode.replaceChild(highlight, wordNode);
return newNodesCreated;
},
removeSearchHighlight: function (element) {
var htmlHighlightQuery = this.htmlSearchHighlightElement + "." + this.htmlSearchHighlightClassName;
var svgHighlightQuery = this.htmlSearchHighlightSvgElement + "." + this.htmlSearchHighlightClassName;
$(element).find(htmlHighlightQuery + "," + svgHighlightQuery).each(function () {
var parent = this.parentNode;
parent.replaceChild(this.firstChild, this);
parent.normalize();
});
},
getWords: function (phrase) {
var separatorsRegexString = "[^" + this.searchSeparatorsList + "]+";
var separatorsRegex = new RegExp(separatorsRegexString, "g");
var matches = phrase.match(separatorsRegex);
var words;
if (matches == null) {
words = null;
}
else {
words = $.map(matches,
function (val, index) {
if (val != '') {
return val;
}
});
}
return words;
},
selectTextInRect: function (rect, clickHandler, pageNumber, selectionCounter, color, hoverHandlers) {
if (this._dvselectable) {
return $(this._dvselectable).dvselectable('highlightPredefinedArea', rect, clickHandler, pageNumber, selectionCounter, color, hoverHandlers);
}
return null;
},
deselectTextInRect: function (rect, deleteStatic, pageNumber, selectionCounter) {
if (this._dvselectable) {
$(this._dvselectable).dvselectable('unhighlightPredefinedArea', rect, deleteStatic, pageNumber, selectionCounter);
}
},
recalculatePageLeft: function () {
if (this._firstPage != null && this.pagesContainerElement != null) {
var pageLeft = this._firstPage.offset().left - this.pagesContainerElement.offset().left;
this.pageLeft(pageLeft);
}
},
reInitSelectable: function () {
var visiblePagesNumbers = this.getVisiblePagesNumbers();
if (this._dvselectable != null) {
this._dvselectable.dvselectable("reInitPages", this.scale(), visiblePagesNumbers,
this.scrollPosition, this.getPageHeight(), this.pages());
}
},
reInitCanvasOffset: function () {
var selectable = this.getSelectableInstance();
selectable.initCanvasOffset();
},
openCurrentPage: function () {
this.setPage(this.pageInd());
},
setPageNumerInUrlHash: function (pageIndex) {
if (this.usePageNumberInUrlHash === undefined || this.usePageNumberInUrlHash == true) {
if (location.hash != "" || pageIndex > 1) {
this.changedUrlHash = true;
location.hash = this.hashPagePrefix + pageIndex.toString();
this.changedUrlHash = false;
}
}
},
isScrollViewerVisible: function () {
var isVisible = this.documentSpace.is(":visible");
return isVisible;
},
getSelectableInstance: function () {
if (this._dvselectable == null)
return null;
var selectable = this._dvselectable.data("ui-dvselectable"); // jQueryUI 1.9+
if (!selectable)
selectable = this._dvselectable.data("dvselectable"); // jQueryUI 1.8
return selectable;
},
shouldMinimumWidthBeUsed: function (width, checkOriginalDocumentWidth) {
var originalDocumentWidth = null;
if (this.use_pdf != 'false' && checkOriginalDocumentWidth) {
var pageSize = this._pdf2XmlWrapper.getPageSize();
originalDocumentWidth = pageSize.width;
}
return this.minimumImageWidth != null &&
(width <= this.minimumImageWidth || (originalDocumentWidth !== null && originalDocumentWidth < this.minimumImageWidth));
},
resizeViewerElement: function (viewerLeft) {
var parent = this.documentSpace.parent();
var parentWidth = parent.width();
if (typeof viewerLeft == "undefined")
viewerLeft = 0;
else
this.viewerLeft = viewerLeft;
this.documentSpace.width(parentWidth - viewerLeft);
this.reInitSelectable();
this.loadImagesForVisiblePages();
},
onPageReordered: function (oldPosition, newPosition) {
this._model.reorderPage(this.fileId, oldPosition, newPosition,
this.instanceIdToken,
function (response) {
if (this.pageContentType == "image") {
var pages = this.pages();
//var page = pages()[oldPosition];
//pages.remove(page);
//pages.splice(newPosition, 0, page);
var pageImageUrl;
var minPosition = Math.min(oldPosition, newPosition);
var maxPosition = Math.max(oldPosition, newPosition);
for (var i = minPosition; i <= maxPosition; i++) {
//pages[i].visible(false);
pageImageUrl = pages[i].url();
pages[i].url(pageImageUrl + "#0"); // to avoid caching
pages[i].visible(true);
//pages[i].url(pageImageUrl);
//pages[i].visible(true);
}
}
if (this._pdf2XmlWrapper)
this._pdf2XmlWrapper.reorderPage(oldPosition, newPosition);
this.reInitSelectable();
this.loadImagesForVisiblePages();
}.bind(this),
function (error) {
this._onError(error);
}.bind(this)
);
},
rotatePage: function (rotationAmount) {
var pageNumber = this.pageInd() - 1;
this._model.rotatePage(this.fileId, pageNumber, rotationAmount,
this.instanceIdToken,
function (response) {
var page = this.pages()[pageNumber];
this.applyPageRotationInBrowser(pageNumber, page, response.resultAngle);
this.reflowPagesInChrome();
this.setPage(pageNumber + 1);
this.loadImagesForVisiblePages(true);
}.bind(this),
function (error) {
this._onError(error);
}.bind(this));
},
applyPageRotationInBrowser: function (pageNumber, page, angle) {
if (!this.supportPageRotation)
return;
var oldRotation = page.rotation();
if (oldRotation == 0 && angle == 0)
return;
if (this.pageContentType == "image" && oldRotation != angle) {
page.visible(false);
this.addSuffixToImageUrl(page);
page.visible(true);
}
page.rotation(angle);
var newAngle = page.rotation() % 180;
var pagesFromServer = this._pdf2XmlWrapper.documentDescription.pages;
var pageSize, pageFromServer;
var pageWidth, pageHeight, maxPageHeight;
if (this.useTabsForPages()) {
var htmlPageContents = this.documentSpace.find(".html_page_contents:first");
var pageElement = htmlPageContents.children("div,table");
pageWidth = pageElement.width();
pageHeight = pageElement.height();
this.initialWidth = pageWidth;
if (newAngle > 0) {
maxPageHeight = pageWidth;
//this.pageWidth(pageHeight * this.zoom() / 100);
}
else {
maxPageHeight = pageHeight;
//this.pageWidth(pageWidth * this.zoom() / 100);
}
this.pageWidth(pageWidth * this.zoom() / 100);
return;
}
else {
if (pagesFromServer) {
pageSize = this.getPageSize();
pageFromServer = pagesFromServer[pageNumber];
pageFromServer.rotation = angle;
pageWidth = pageFromServer.w;
pageHeight = pageFromServer.h;
maxPageHeight = pageSize.height;
}
else
return;
}
var scaleRatio;
if (newAngle > 0) {
page.prop(pageWidth / pageHeight);
if (this.pageContentType == "html") {
scaleRatio = this.getScaleRatioForPage(pageSize.width, pageSize.height, pageHeight, pageWidth);
page.heightRatio(scaleRatio);
}
}
else {
page.prop(pageHeight / pageWidth);
if (this.pageContentType == "html") {
scaleRatio = this.getScaleRatioForPage(pageSize.width, pageSize.height, pageWidth, pageHeight);
page.heightRatio(scaleRatio);
}
}
this.calculatePagePositionsForVirtualMode();
this.reInitSelectable();
var selectable = this.getSelectableInstance();
if (selectable != null)
selectable.clearSelectionOnPage(pageNumber);
this.loadImagesForVisiblePages(true);
},
_calculatePageSizeFromDOM: function () {
var htmlPageContents = this.documentSpace.find(".html_page_contents:first");
var pageElement = htmlPageContents.children("div,table,img");
if (this.autoHeight()) {
var pageWidth = pageElement.width();
this.initialWidth = pageWidth;
}
this.pageWidth(this.initialWidth * this.zoom() / 100);
var dimensions = pageElement[0].getBoundingClientRect();
var reserveHeight = 0;
this.autoHeight(true);
var page = this.pages()[0];
var screenWidth;
var screenHeight;
if (typeof dimensions.width == "undefined") // IE8
screenWidth = dimensions.right - dimensions.left;
else
screenWidth = dimensions.width;
if (typeof dimensions.height == "undefined") // IE8
screenHeight = dimensions.bottom - dimensions.top;
else
screenHeight = dimensions.height;
if (page && page.rotation && page.rotation() % 180 > 0) {
var t = screenWidth;
screenWidth = screenHeight;
screenHeight = t;
}
screenHeight += reserveHeight;
page.prop(screenHeight / screenWidth);
this.autoHeight(false);
},
reflowPagesInChrome: function (async) {
/* a hack to make Chrome reflow pages after changing their size
when SVG watermarks are enabled */
if (this.browserIsChrome() && this.watermarkText && !this.useVirtualScrolling) {
var self = this;
var internalReflow = function () {
self.pagesContainerElement.children().each(function () {
$(this).css("top", 0).css("left", 0);
});
};
if (async)
window.setTimeout(internalReflow, 10);
else
internalReflow();
}
},
getHtmlElements: function (pageHtml, tagName) {
var contentsRegex = new RegExp("<" + tagName + "[^>]*>(?:.|\\r?\\n)*?<\\/" + tagName + ">", "gi");
var contentsFromHtml = pageHtml.match(contentsRegex);
return contentsFromHtml;
},
getHtmlElementContents: function (pageHtml, tagName) {
var contentsRegex = new RegExp("<" + tagName + "[^>]*>((?:.|\\r?\\n)*?)<\\/" + tagName + ">", "i");
var match = pageHtml.match(contentsRegex);
var contentsFromHtml = null;
if (match)
contentsFromHtml = match[1];
return contentsFromHtml;
},
getHtmlElementAttributess: function (pageHtml, tagName) {
var contentsRegex = new RegExp("<" + tagName + "[^>]*/?>", "gi");
var contentsFromHtml = pageHtml.match(contentsRegex);
return contentsFromHtml;
},
getPageBodyContents: function (pageHtml) {
var bodyContentsFromHtml = pageHtml.match(/<body[^>]*>((?:.|\r?\n)*?)<\/body>/)[1];
return bodyContentsFromHtml;
},
getPageBodyContentsWithReplace: function (pageHtml) {
//var matches = pageHtml.match(/(<body)([^>]*>)((?:.|\r?\n)*?)(<\/body>)/);
//var bodyContentsFromHtml = "<div" + matches[2] + matches[3] + "</div>";
var bodStartTag = "<body";
var bodyTagStartPos = pageHtml.indexOf(bodStartTag);
var bodyStartPos = bodyTagStartPos + bodStartTag.length;
var bodyEndPos = pageHtml.indexOf("/body>");
var bodyContentsFromHtml = "<div" + pageHtml.substr(bodyStartPos, bodyEndPos - bodyStartPos) + "/div>";
return bodyContentsFromHtml;
},
isPageVisible: function (pageNumber) {
return this.pages()[pageNumber].visible();
},
getPageLocations: function () {
return this.getSelectableInstance().pageLocations;
},
getPageSize: function () {
var pageSize = this._pdf2XmlWrapper.getPageSize();
return pageSize;
},
fixImageReferencesInHtml: function (pageHtml) {
var bodyContentsFromHtml = this.getPageBodyContents(pageHtml);
//var pageElement = $("<div/>").hide();
//pageElement.html(bodyContentsFromHtml);
//var imagesInPage = pageElement.find("object[type='image/svg+xml']");
//var svgPath;
//var urlForImagesInHtml = this.urlForImagesInHtml;
//imagesInPage.each(function () {
//    var that = $(this);
//    svgPath = that.attr("data");
//    svgPath = urlForImagesInHtml.replace("(0)", svgPath);
//    that.attr("data", svgPath);
//    var embeddedChild = that.children();
//    embeddedChild.attr("data", svgPath);
//    embeddedChild.attr("src", svgPath);
//});
//var bodyContentsWithFixedUrls = pageElement.html();
//return bodyContentsWithFixedUrls;
return bodyContentsFromHtml;
},
calculatePointToPixelRatio: function () {
var pointWidth = 100;
var testElement = $("<div/>").css("width", pointWidth + "pt").css("height", "0");
testElement.appendTo(this.documentSpace);
var pixelWidth = testElement.width();
this.pointToPixelRatio = pixelWidth / pointWidth;
testElement.remove();
},
activateTab: function (number) {
var tab = this.tabs()[number];
var self = this;
function activateLoadedTab() {
var pages = self.pages();
var page = pages[0];
page.htmlContent(tab.htmlContent());
var htmlPageContents = self.documentSpace.find(".html_page_contents:first");
var pageElement = htmlPageContents.children("div,table");
var pageWidth = pageElement.width();
self.initialWidth = pageWidth;
page.prop(pageElement.height() / pageWidth);
self.pageWidth(pageWidth * self.zoom() / 100);
self.activeTab(number);
if (self.supportPageRotation)
self.applyPageRotationInBrowser(0, page, page.rotation());
}
if (tab.visible()) {
activateLoadedTab();
}
else {
this.getDocumentPageHtml(number, function () {
activateLoadedTab();
});
}
},
adjustInitialZoom: function () {
var zoomIsSet = false;
if (this.zoomToFitHeight) {
zoomIsSet = true;
this.setZoom(this.getFitHeightZoom());
}
else if (this.pageContentType == "html" && this.zoomToFitWidth) {
//this.initialWidth = this.pageImageWidth = this.getFitWidth();
var fittingWidth = this.getFitWidth();
var originalPageWidth = this.pageWidth();
if (!this.onlyShrinkLargePages || originalPageWidth > fittingWidth) {
var zoom = fittingWidth / originalPageWidth * 100;
zoomIsSet = true;
this.setZoom(zoom);
}
}
if (!zoomIsSet && this.useTabsForPages()) {
this._calculatePageSizeFromDOM();
}
},
intToColor: function (num) {
if (num === null)
num = 0xFFFF0000; // default is red
else
num >>>= 0;
var b = num & 0xFF,
g = (num & 0xFF00) >>> 8,
r = (num & 0xFF0000) >>> 16,
a = ((num & 0xFF000000) >>> 24) / 255;
return "rgba(" + [r, g, b, a].join(",") + ")";
},
watermarkTransform: function (page, element) {
var rotation = 0;
if (page.rotation)
rotation = page.rotation();
var pageProportion = page.prop();
var top = "Top", bottom = "Bottom", diagonal = "Diagonal";
var left = "Left", center = "Center", right = "Right";
var vertical = "", horizontal = center;
if (this.watermarkPosition.indexOf(top) == 0)
vertical = top;
else if (this.watermarkPosition.indexOf(bottom) == 0)
vertical = bottom;
else if (this.watermarkPosition.indexOf(diagonal) == 0) {
vertical = diagonal;
horizontal = center;
}
if (vertical != diagonal) {
if (this.watermarkPosition.indexOf(left) != -1)
horizontal = left;
else if (this.watermarkPosition.indexOf(center) != -1)
horizontal = center;
else if (this.watermarkPosition.indexOf(right) != -1)
horizontal = right;
}
var returnValue = "translate";
//var widthWithoutMargin = this.pageWidth();
//var pageWidth = widthWithoutMargin + this.imageHorizontalMargin;
//var pageHeight = widthWithoutMargin * pageProportion;
var fontHeight = 10;
var pageWidth = 100;
var pageHeight = pageWidth * pageProportion;
var textWidth;
if (this.watermarkScreenWidth == null) {
var textSize = element.getBBox();
this.watermarkScreenWidth = textSize.width;
}
textWidth = this.watermarkScreenWidth;
var scale;
if (this.watermarkWidth == 0)
scale = 1;
else
scale = this.watermarkWidth / 100.;
var smallerSide = pageWidth;
if (vertical == diagonal && pageHeight < pageWidth) {
smallerSide = pageHeight;
}
var watermarkWidth = smallerSide * scale;
var scaleToFitIntoPageWidth = smallerSide / textWidth;
if (rotation % 180 != 0 && vertical != diagonal) {
watermarkWidth = pageHeight * scale;
scaleToFitIntoPageWidth = pageHeight / textWidth;
}
scale *= scaleToFitIntoPageWidth;
var horizontalCenter = pageWidth / 2;
var verticalCenter = pageHeight / 2;
var horizontalShift = 0;
switch (horizontal) {
case center:
horizontalShift = ((pageWidth - watermarkWidth) / 2);
break;
case left:
horizontalShift = 0;
break;
case right:
horizontalShift = pageWidth - watermarkWidth;
break;
}
//Adjust vertical shift in order to eliminate text cropping
var verticalShift;
if (vertical === bottom) {
verticalShift = (pageHeight - pageHeight * scale - 8);
}
else if (vertical === diagonal) {
verticalShift = (pageHeight - pageHeight * scale);
}
else {//(vertical == top)
verticalShift = 0;
}
returnValue += '(' + horizontalShift + "," + verticalShift + ')' +
'scale(' + scale + ')';
if (vertical == diagonal)
returnValue += 'translate(0,' + (-verticalCenter / scale) + ') rotate(' + (-50 + rotation) + ',' + (horizontalCenter - horizontalShift) / scale + ',' + pageHeight + ') ';
if (!page.rotation || vertical == diagonal)
return returnValue;
//var screenCenterMinusFontHeight = screenCenter - 10;
var firstShift = 0, secondShift = 0, secondHorizontalShift = 0;
var rotationCenterX, rotationCenterY = 0;
if (horizontal == center) {
rotationCenterX = (horizontalCenter - horizontalShift) / scale;
if (vertical == top) {
rotationCenterY = 0;
}
else {
rotationCenterY = pageHeight;
}
}
else if (horizontal == left) {
rotationCenterX = horizontalCenter / scale;
if (rotation % 180 != 0)
secondHorizontalShift = (horizontalCenter - verticalCenter) / scale;
if (vertical == top) {
rotationCenterY = 0;
}
else {
rotationCenterY = pageHeight;
}
}
else if (horizontal == right) {
rotationCenterX = -(horizontalShift - horizontalCenter) / scale;
if (rotation % 180 != 0)
secondHorizontalShift = -(horizontalCenter - verticalCenter) / scale;
if (vertical == top) {
rotationCenterY = 0;
}
else {
rotationCenterY = pageHeight;
}
}
switch (rotation) {
case 90:
if (vertical == top) {
firstShift = verticalCenter / scale;
secondShift = -horizontalCenter / scale;
}
else {
firstShift = -verticalCenter / scale;
secondShift = horizontalCenter / scale;
}
break;
case 180:
if (vertical == top) {
firstShift = verticalCenter / scale;
secondShift = -verticalCenter / scale;
}
else {
firstShift = -verticalCenter / scale;
secondShift = verticalCenter / scale;
}
break;
case 270:
if (vertical == top) {
firstShift = verticalCenter / scale;
secondShift = -horizontalCenter / scale;
}
else {
firstShift = -verticalCenter / scale;
secondShift = horizontalCenter / scale;
}
break;
}
if (vertical == top || vertical == bottom)
returnValue += 'translate(0,' + firstShift + ') rotate(' + rotation + ',' + rotationCenterX + ',' + rotationCenterY + ') translate(' + secondHorizontalShift + ',' + secondShift + ')';
return returnValue;
},
addSuffixToImageUrl: function (page) {
var src = page.url();
var prefixChar = "?";
var dummyIndex = src.indexOf('dummy=');
if (dummyIndex != -1) {
src = src.substring(0, dummyIndex - 1);
}
var paramsIndex = src.indexOf('?');
if (paramsIndex != -1)
prefixChar = "&";
page.url(src + prefixChar + 'dummy=' + new Date().getTime());
},
isRTL: function (s) {
return false; // Aspose.Words 15.3 fixes RTL text
var ltrChars = 'A-Za-z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u02B8\u0300-\u0590\u0800-\u1FFF' + '\u2C00-\uFB1C\uFDFE-\uFE6F\uFEFD-\uFFFF',
rtlChars = '\u0591-\u07FF\uFB1D-\uFDFD\uFE70-\uFEFC',
rtlDirCheck = new RegExp('^[^' + ltrChars + ']*[' + rtlChars + ']');
return rtlDirCheck.test(s);
},
setLoadingState: function (set) {
this.inprogress(set);
},
getScaleRatioForPage: function (widthForMaxHeight, maxPageHiegt, pageWidth, pageHeight) {
var widthRatio, scaleRatio;
if (widthForMaxHeight === undefined)
widthRatio = 1;
else
widthRatio = widthForMaxHeight / pageWidth;
scaleRatio = widthRatio;
return scaleRatio;
},
pageElementStyle: function (index) {
var result = {};
var pages = this.pages();
if (this.useVirtualScrolling) {
var firstVisiblePageNum = this.firstVisiblePageForVirtualMode();
index += firstVisiblePageNum;
if (firstVisiblePageNum < pages.length)
result.top = pages[firstVisiblePageNum].top() + 'px';
}
else
result.top = '';
if (this.layout() == this.Layouts.OnePageInRow) {
result.display = 'block';
result.marginLeft = 'auto';
result.marginRight = 'auto';
}
else {
result.display = '';
result.marginLeft = '';
result.marginRight = '';
}
var pageWidth = this.pageWidth();
if (this.options.useEmScaling) {
result.width = this.serverPages[index].w * this.pointToPixelRatio / 16. + 'em';
result.height = this.serverPages[index].h * this.pointToPixelRatio / 16. + 'em';
}
else {
result.width = pageWidth + (this.useHtmlBasedEngine ? this.imageHorizontalMargin : 0) + 'px';
if (this.autoHeight()) {
result.width = 'auto';
result.height = 'auto';
result.overflow = 'visible';
}
else {
if (index < pages.length)
result.height = pageWidth * pages[index].prop() + 'px';
result.overflow = 'hidden';
}
}
return result;
},
setLayout: function (layout) {
this.layout(layout);
this.calculatePagePositionsForVirtualMode();
this.loadImagesForVisiblePages();
this.documentSpace.trigger("layoutChanged.groupdocs");
},
calculatePagePositionsForVirtualMode: function () {
if (this.useVirtualScrolling) {
var pageVerticalMargin = 15; // pixels
var pageHorizontalMargin = 2 * 7; // pixels
var pages = this.pages();
var width = this.pageWidth();
var documentHeight = 0;
var page, proportion, pageHeight;
var pageLeft = 0, pageTop = 0;
var rowHeight = 0;
var pagesInRow;
var layout = this.layout();
switch (layout) {
case this.Layouts.ScrollMode:
pagesInRow = Math.floor(this.pagesContainerElement.width() / this.pageWidth());
if (pagesInRow == 0)
pagesInRow = 1;
break;
case this.Layouts.OnePageInRow:
pagesInRow = 1;
break;
case this.Layouts.TwoPagesInRow:
case this.Layouts.CoverThenTwoPagesInRow:
pagesInRow = 2;
break;
}
var isFirstPageInRow, isLastPageInRow;
for (var i = 0; i < pages.length; i++) {
page = pages[i];
proportion = page.prop();
pageHeight = width * proportion;
page.left = pageLeft;
page.top(pageTop);
isFirstPageInRow = (layout != this.Layouts.CoverThenTwoPagesInRow && i % pagesInRow == 0)
|| (layout == this.Layouts.CoverThenTwoPagesInRow && (i == 0 || i % pagesInRow == 1));
isLastPageInRow = layout == this.Layouts.OnePageInRow
|| (layout == this.Layouts.TwoPagesInRow && i % pagesInRow == 1)
|| (layout == this.Layouts.CoverThenTwoPagesInRow && (i == 0 || i % pagesInRow == 0))
|| (layout == this.Layouts.ScrollMode && i % pagesInRow == pagesInRow - 1);
if (isFirstPageInRow || (!isFirstPageInRow && pageHeight > rowHeight))
rowHeight = pageHeight;
documentHeight = pageTop + rowHeight + pageVerticalMargin;
if (isLastPageInRow) {
pageTop += rowHeight + pageVerticalMargin;
pageLeft = 0;
}
else
pageLeft += width + pageHorizontalMargin;
}
this.documentHeight(documentHeight);
}
},
triggerEvent: function (name, params) {
this.documentSpace.trigger(name, params);
},
clearContentControls: function () {
if (!this.supportListOfContentControls || !this.contentControlsFromHtml)
return;
var contentControlFromHtml;
for (var i = 0; i < this.contentControlsFromHtml.length; i++) {
contentControlFromHtml = this.contentControlsFromHtml[i];
if (typeof contentControlFromHtml != "undefined" && contentControlFromHtml.visualWrapper) {
contentControlFromHtml.visualWrapper.remove();
}
}
this.contentControlsFromHtml.length = 0;
},
markContentControls: function (pageNumber) {
if (!this.supportListOfContentControls || !this.contentControls)
return;
var i, contentControlFromHtml;
for (i = 0; i < this.contentControlsFromHtml.length; i++) {
contentControlFromHtml = this.contentControlsFromHtml[i];
if (typeof contentControlFromHtml != "undefined" && contentControlFromHtml.pageNumber == pageNumber) {
return;
}
}
//"2D5FABC2_1start1=Document_-_Document_"
var contentControlGuid = "2D5FABC2";
var startType = "start";
var endType = "end";
var separator = "=";
var spaceToSearchIn = this.documentSpace;
if (typeof pageNumber != "undefined")
spaceToSearchIn = this.documentSpace.find("#" + this.pagePrefix + (pageNumber + 1).toString());
spaceToSearchIn.find(".content_control_visual_wrapper").remove();
var contentControlMarkers = spaceToSearchIn.find("a[name^='" + contentControlGuid + "']");
var contentControlsFromHtml = new Array();
var wrappersRemain = 0;
var contentControlNumber;
var self = this;
contentControlMarkers.each(function () {
var that = $(this);
var name = that.attr("name");
var typePositionRegex = new RegExp("(" + startType + ")|(" + endType + ")");
var typePosition = name.search(typePositionRegex);
var contentControlNumberText = name.substring(contentControlGuid.length + 1, typePosition);
contentControlNumber = parseInt(contentControlNumberText);
if (pageNumber >= self.contentControls[contentControlNumber].startPage
&& pageNumber <= self.contentControls[contentControlNumber].endPage) {
if (name.indexOf(startType) == typePosition) {
var contentControlTitlePosition = name.indexOf(separator, typePosition) + 1;
var contentControlTitle = name.substring(contentControlTitlePosition, name.length);
var moveUpInDom = name[typePosition + startType.length] == "1";
var startElement = that;
if (typeof contentControlsFromHtml[contentControlNumber] == "undefined") {
if (moveUpInDom || startElement.parent().children(":not([name^='" + contentControlGuid + "'])").length == 0)
startElement = startElement.parent();
contentControlsFromHtml[contentControlNumber] = {
title: contentControlTitle,
number: contentControlNumber
};
}
contentControlsFromHtml[contentControlNumber].startElement = startElement;
contentControlsFromHtml[contentControlNumber].moveUpInDom = moveUpInDom;
}
else {
if (that.parent().children(":not([name^='" + contentControlGuid + "'])").length == 0)
that = that.parent();
if (typeof contentControlsFromHtml[contentControlNumber] == "undefined") {
contentControlsFromHtml[contentControlNumber] = { endElement: that, number: contentControlNumber };
}
contentControlsFromHtml[contentControlNumber].endElement = that;
}
}
});
for (i = 0; i < this.contentControls.length; i++) {
if (pageNumber >= this.contentControls[i].startPage
&& pageNumber <= this.contentControls[i].endPage) {
if (!contentControlsFromHtml[i]) {
contentControlsFromHtml[i] = {
number: i, title: this.contentControls[i].title
};
}
}
}
for (i = 0; i < contentControlsFromHtml.length; i++) {
contentControlFromHtml = contentControlsFromHtml[i];
if (contentControlFromHtml) {
if (!contentControlFromHtml.startElement) {
contentControlFromHtml.startElement = spaceToSearchIn
.children(".html_page_contents").children(".pageWordToHtml").children(":first");
}
if (!contentControlFromHtml.endElement) {
contentControlFromHtml.endElement = spaceToSearchIn
.children(".html_page_contents").children(".pageWordToHtml").children(":last");
}
contentControlFromHtml.title = this.contentControls[i].title;
contentControlFromHtml.pageNumber = pageNumber;
wrappersRemain++;
(function (contentControlNumberInner) {
window.setTimeout(function () {
wrappersRemain--;
self.createContentControlWrappers(spaceToSearchIn, contentControlsFromHtml, contentControlNumberInner, contentControlGuid, wrappersRemain);
}, 2000);
})(i);
}
}
},
createContentControlWrappers: function (spaceToSearchIn, contentControlsFromHtml, contentControlNumber, contentControlGuid, wrappersRemain) {
var contentControlFromHtml = contentControlsFromHtml[contentControlNumber];
var startElement = contentControlFromHtml.startElement;
var endElement = contentControlFromHtml.endElement;
var top = startElement.offset().top;
top -= this.pagesContainerElement.offset().top;
var contentControlVisualWrapper = $("<div/>").appendTo(spaceToSearchIn);
contentControlFromHtml.visualWrapper = contentControlVisualWrapper;
contentControlVisualWrapper.addClass("content_control_visual_wrapper");
var elementsBetween = startElement.nextUntil(endElement, ":not([name^='" + contentControlGuid + "'])").add(endElement);
if (contentControlFromHtml.moveUpInDom)
elementsBetween = elementsBetween.add(startElement);
var childrenBetween = elementsBetween.find("*");
elementsBetween = elementsBetween.add(childrenBetween);
var minLeft = null, maxRight = null, minTop = null, maxBottom = null;
var innerElementLeft, innerElementWidth, innerElementTop, innerElementHeight;
var currentZoom = this.zoom() / 100;
elementsBetween.each(function () {
var innerElement = $(this);
if (innerElement.width() == 0 || innerElement.height() == 0)
return;
innerElementLeft = innerElement.offset().left;
if (minLeft === null || innerElementLeft < minLeft)
minLeft = innerElementLeft;
innerElementWidth = innerElement.width() * currentZoom;
if (maxRight === null || innerElementLeft + innerElementWidth > maxRight)
maxRight = innerElementLeft + innerElementWidth;
innerElementTop = innerElement.offset().top;
if (minTop === null || innerElementTop < minTop)
minTop = innerElementTop;
innerElementHeight = innerElement.height() * currentZoom;
if (maxBottom === null || innerElementTop + innerElementHeight > maxBottom)
maxBottom = innerElementTop + innerElementHeight;
});
//var containerOffsetLeft = self.pagesContainerElement.offset().left;
//var containerOffsetTop = self.pagesContainerElement.offset().top;
var containerOffsetLeft = spaceToSearchIn.offset().left;
var containerOffsetTop = spaceToSearchIn.offset().top;
contentControlVisualWrapper.css("left", (minLeft - containerOffsetLeft) + "px");
contentControlVisualWrapper.css("width", maxRight - minLeft + "px");
contentControlVisualWrapper.css("top", (minTop - containerOffsetTop) + "px");
contentControlVisualWrapper.css("height", maxBottom - minTop + "px");
contentControlVisualWrapper.attr("data-title", contentControlFromHtml.title);
if (wrappersRemain == 0) {
contentControlsFromHtml.sort(function (a, b) {
if (a.visualWrapper && b.visualWrapper)
return b.visualWrapper.width() * b.visualWrapper.height() - a.visualWrapper.width() * a.visualWrapper.height();
else
return 0;
});
var startZIndex = 1;
for (var i = 0; i < contentControlsFromHtml.length; i++) {
contentControlFromHtml = contentControlsFromHtml[i];
if (typeof contentControlFromHtml != "undefined" && contentControlFromHtml.visualWrapper) {
contentControlFromHtml.visualWrapper.css("z-index", i + startZIndex);
if (this.contentControlToBeOpened !== null && this.contentControlToBeOpened == contentControlFromHtml.number) {
this.visuallySelectContentControl(contentControlFromHtml);
this.contentControlToBeOpened = null;
}
}
this.contentControlsFromHtml.push(contentControlsFromHtml[i]);
}
}
},
getContentControlDescriptions: function () {
return this.contentControls;
},
navigateToContentControl: function (number) {
number = parseInt(number);
var pageNumber = this.contentControls[number].startPage;
var found = false;
if (this.pages()[pageNumber].visible()) {
var contentControlFromHtml;
for (var i = 0; i < this.contentControlsFromHtml.length; i++) {
contentControlFromHtml = this.contentControlsFromHtml[i];
if (typeof contentControlFromHtml != "undefined" && contentControlFromHtml.number == number) {
this.visuallySelectContentControl(contentControlFromHtml);
found = true;
break;
}
}
}
if (!found) {
this.contentControlToBeOpened = number;
this.setPage(pageNumber + 1);
}
},
visuallySelectContentControl: function (contentControlFromHtml) {
var contentControlHeaderHeight = 20;
this.documentSpace[0].scrollTop = contentControlFromHtml.visualWrapper.offset().top -
this.pagesContainerElement.offset().top -
contentControlHeaderHeight;
var hoverClass = "hover";
var allWrappers = this.documentSpace.find(".doc-page .content_control_visual_wrapper");
allWrappers.removeClass(hoverClass);
allWrappers.unbind("mouseleave");
contentControlFromHtml.visualWrapper.addClass(hoverClass);
allWrappers.bind("mouseleave", function () {
contentControlFromHtml.visualWrapper.removeClass(hoverClass);
allWrappers.unbind("mouseleave");
});
this.documentSpace.trigger("ScrollDocView", [null, { target: this.documentSpace[0] }]);
this.documentSpace.trigger("ScrollDocViewEnd", [null, { target: this.documentSpace[0] }]);
},
initCustomBindings: function () {
if (!ko.bindingHandlers.searchText) {
ko.bindingHandlers.searchText = {
update: function (element, valueAccessor, allBindings, viewModelParam, bindingContext) {
var viewModel = bindingContext.$root;
var page = bindingContext.$data;
if (!page.searched) {
var value = ko.utils.unwrapObservable(valueAccessor());
viewModel.parseSearchParameters(element, value);
}
page.searched = false;
}
};
}
if (!ko.bindingHandlers.parsedHtml) {
ko.bindingHandlers.parsedHtml = {
init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
var modelValue = valueAccessor();
var jqueryElement = $(element);
var elementValue = jqueryElement.html();
if (ko.isWriteableObservable(modelValue)) {
modelValue(elementValue);
}
else { //handle non-observable one-way binding
var allBindings = allBindingsAccessor();
if (allBindings['_ko_property_writers'] && allBindings['_ko_property_writers'].parsedHtml)
allBindings['_ko_property_writers'].parsedHtml(elementValue);
}
},
update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
var value = ko.unwrap(valueAccessor()) || "";
var page = bindingContext.$data;
var jqueryElement = $(element);
jqueryElement.empty();
if (value) {
if (typeof page.currentValue == "undefined"
|| page.currentValue === null
|| page.currentValue != value) {
var trimmedValue = value.replace(/^[\r\n\s]+|[\r\n\s]+$/g, "");
page.parsedHtmlElement = $(trimmedValue);
page.currentValue = value;
}
jqueryElement.append(page.parsedHtmlElement);
}
else {
page.parsedHtmlElement = null;
page.currentValue = null;
}
}
};
}
},
parseSearchParameters: function (element, value) {
var viewModel = this;
viewModel.removeSearchHighlight(element);
if (value) {
var text = value.text;
if (text) {
var words;
var isCaseSensitive = value.isCaseSensitive;
var treatTextAsExact = false;
if (value.treatPhrasesInDoubleQuotesAsExact) {
var trimmedText = text.replace(/^[\r\n\s]+|[\r\n\s]+$/g, "");
if (trimmedText.length >= 2 && trimmedText[0] == '"' && trimmedText[trimmedText.length - 1] == '"') {
text = text.substr(1, trimmedText.length - 2);
text = text.replace(/^[\r\n\s]+|[\r\n\s]+$/g, "");
viewModel.currentWordCounter = 0;
viewModel.matchedNods = [];
viewModel.searchMatches = [];
viewModel.matchedNodsCount = 0;
treatTextAsExact = true;
}
}
var reservedSymbolsRegExp = /[-[\]{}()*+?.,\\^$|#\s]/g;
words = viewModel.getWords(text);
if (words == null)
return;
words = jQuery.map(words, function (word, i) {
return word.replace(reservedSymbolsRegExp, "\\$&");
});
var wordsWithAccentedChars = words;
var processedWord;
if (viewModel.useAccentInsensitiveSearch || viewModel.useRtl) {
wordsWithAccentedChars = new Array();
for (wordNum = 0; wordNum < words.length; wordNum++) {
processedWord = words[wordNum];
if (viewModel.useAccentInsensitiveSearch)
processedWord = window.jGroupdocs.stringExtensions.getAccentInsensitiveRegexFromString(processedWord);
//if (viewModel.useRtl)
//    processedWord = window.jGroupdocs.stringExtensions.unicodeEscape(processedWord);
wordsWithAccentedChars.push(processedWord);
}
}
viewModel.searchHtmlElement(element, null, null, words, wordsWithAccentedChars,
value.searchForSeparateWords, isCaseSensitive, treatTextAsExact, value.pageNumber);
return;
}
}
},
highlightSearch: function () {
if (this.pageContentType == "image" && this.useVirtualScrolling) {
var selectable = this.getSelectableInstance();
if (selectable) {
selectable.highlightSearch(
this.firstVisiblePageForVirtualMode(),
this.lastVisiblePageForVirtualMode());
}
}
},
firePageImageLoadedEvent: function (pageNumber, event) {
this.firePageImageEvent(pageNumber, event, false);
},
firePageImageLoadErrorEvent: function (pageNumber, event) {
this.firePageImageEvent(pageNumber, event, true);
},
firePageImageEvent: function (pageNumber, event, isErrorEvent) {
var domElement = event.target;
if (this.useFullSizeImages || isErrorEvent) {
var pages = this.pages();
var page = null;
if (pageNumber < pages.length)
page = pages[pageNumber];
if (page) {
if (page.visible()) {
page.domElement = domElement;
if (isErrorEvent) {
this.triggerEvent("pageImageLoadError.groupdocs", [pageNumber, domElement]);
this._onError({ Reason: "The page " + pageNumber + " can't be loaded" });
}
else
this.triggerEvent("pageImageLoaded.groupdocs", [pageNumber, domElement]);
}
}
}
},
raiseDocumentLoadCompletedEvent: function () {
this.documentSpace.trigger("documentLoadCompleted.groupdocs");
},
_setTextPositionsCalculationFinished: function (value) {
if (!this._isTextPositionsCalculationFinished) {
this._isTextPositionsCalculationFinished = value;
if (value)
this.raiseDocumentLoadCompletedEvent();
}
}
});
})(jQuery);
DocViewerAdapter = function (options) {
$.extend(this, options);
this.init();
};
$.extend(DocViewerAdapter.prototype, {
docViewerWidget: null,
docViewerViewModel: null,
navigationWidget: null,
navigationViewModel: null,
thumbnailsWidget: null,
thumbnailsViewModel: null,
zoomViewModel: null,
init: function () {
var docViewer = null;
var navigation = null;
var thumbnails = null;
var zooming = null;
var search = null;
var embedSource = null;
var viewTypeMenu = null;
var docViewerViewModel = null;
var navigationViewModel = null;
var thumbnailsViewModel = null;
var zoomViewModel = null;
var searchViewModel = null;
var embedSourceViewModel = null;
var viewTypeViewModel = null;
var menuClickedEvent = "onMenuClicked";
if (this.thumbnails) {
thumbnails = this.thumbnails.thumbnails(this.thumbnailsOptions || { baseUrl: this.baseUrl,
quality: this.quality,
use_pdf: this.use_pdf
});
thumbnailsViewModel = this.thumbnails.thumbnails('getViewModel');
}
else {
thumbnails = this.thumbnailsCreator();
thumbnailsViewModel = this.thumbnailsViewModelCreator();
}
var thumbnailsPanelWidth = 0;
if (this.thumbnails)
thumbnailsPanelWidth = thumbnailsViewModel.getThumbnailsPanelWidth();
if (this.docSpace) {
var viewerOptions = $.extend(
{
userId: this.userId,
userKey: this.userKey,
baseUrl: this.baseUrl,
fileId: this.fileId,
fileVersion: this.fileVersion,
quality: this.quality,
use_pdf: this.use_pdf,
pageImageWidth: this.pageImageWidth,
_mode: this._mode,
docViewerId: this.docViewerId,
createHtml: this.createHtml,
initialZoom: this.initialZoom,
alwaysOnePageInRow: this.alwaysOnePageInRow,
zoomToFitWidth: this.zoomToFitWidth,
zoomToFitHeight: this.zoomToFitHeight,
viewerLeft: thumbnailsPanelWidth,
viewerWidth: this.viewerWidth,
viewerHeight: this.viewerHeight,
preloadPagesCount: this.preloadPagesCount,
selectionContent: this.selectionContent,
usePageNumberInUrlHash: this.usePageNumberInUrlHash,
pageContentType: this.pageContentType,
imageHorizontalMargin: this.imageHorizontalMargin,
imageVerticalMargin: this.imageVerticalMargin,
useJavaScriptDocumentDescription: this.useJavaScriptDocumentDescription,
searchPartialWords: this.searchPartialWords,
variableHeightPageSupport: this.variableHeightPageSupport,
textSelectionSynchronousCalculation: this.textSelectionSynchronousCalculation,
minimumImageWidth: this.minimumImageWidth,
fileDisplayName: this.fileDisplayName,
preventTouchEventsBubbling: this.preventTouchEventsBubbling,
watermarkText: this.watermarkText,
instanceId: this.instanceId
}, this.viewerOptions);
docViewer = this.docSpace.docViewer(viewerOptions);
docViewerViewModel = this.docSpace.docViewer('getViewModel');
}
else {
docViewer = this.docSpaceCreator();
docViewerViewModel = this.docSpaceViewModel();
}
var docViewerPageFlip = null;
var docViewerPageFlipViewModel = null;
if (this.docSpacePageFlip) {
docViewerPageFlip = this.docSpacePageFlip.docViewerPageFlip({
userId: this.userId,
userKey: this.userKey,
baseUrl: this.baseUrl,
fileId: this.fileId,
fileVersion: this.fileVersion,
quality: this.quality,
use_pdf: this.use_pdf,
pageImageWidth: this.pageImageWidth,
_mode: this._mode,
docViewerId: this.docViewerId,
createHtml: this.createHtml,
initialZoom: this.initialZoom,
alwaysOnePageInRow: this.alwaysOnePageInRow,
zoomToFitWidth: this.zoomToFitWidth,
zoomToFitHeight: this.zoomToFitHeight,
viewerWidth: this.viewerWidth,
viewerHeight: this.viewerHeight,
selectionContent: this.selectionContent,
minimumImageWidth: this.minimumImageWidth
});
docViewerPageFlipViewModel = this.docSpacePageFlip.docViewerPageFlip('getViewModel');
}
if (this.navigation) {
navigation = this.navigation.navigation(this.navigationOptions);
navigationViewModel = this.navigation.navigation('getViewModel');
}
if (this.search) {
search = this.search.search($.extend(this.searchOptions, { viewerViewModel: docViewerViewModel }));
searchViewModel = this.search.search('getViewModel');
}
if (this.zooming) {
zooming = this.zooming.zooming(this.zoomingOptions || {});
zoomViewModel = this.zooming.zooming('getViewModel');
}
if (this.embedSource) {
embedSource = this.embedSource.embedSource();
embedSourceViewModel = this.embedSource.embedSource('getViewModel');
}
if (this.viewTypeMenu) {
viewTypeMenu = this.viewTypeMenu;
viewTypeViewModel = this.viewTypeViewModel;
}
this.docViewerViewModel = docViewerViewModel;
this.docViewerPageFlipViewModel = docViewerPageFlipViewModel;
this.navigationViewModel = navigationViewModel;
this.thumbnailsViewModel = thumbnailsViewModel;
this.zoomViewModel = zoomViewModel;
this.searchViewModel = searchViewModel;
this.embedSourceViewModel = embedSourceViewModel;
docViewer.bind('getPagesCount', function (e, pagesCount) {
if (navigation) {
navigationViewModel.setPagesCount(pagesCount);
}
} .bind(this));
docViewer.bind("onDocumentloadingStarted", function (e) {
if (thumbnails) {
thumbnailsViewModel.hideThumbnails();
}
} .bind(this));
docViewer.bind("documentLoadFailed.groupdocs", function (e) {
if (thumbnails) {
thumbnailsViewModel.showThumbnails(true);
}
} .bind(this));
docViewer.bind('_onProcessPages', function (e, data, pages, getDocumentPageHtmlCallback, viewerViewModel, pointToPixelRatio, docViewerId) {
if (thumbnails) {
thumbnailsViewModel.onProcessPages(data, pages, getDocumentPageHtmlCallback, viewerViewModel, pointToPixelRatio, docViewerId);
}
} .bind(this));
docViewer.bind('onScrollDocView', function (e, data) {
if (thumbnails) {
thumbnailsViewModel.setThumbnailsScroll(data);
}
if (navigation) {
navigationViewModel.setPageIndex(data.pi);
}
if (search) {
searchViewModel.scrollPositionChanged(data.position);
}
} .bind(this));
docViewer.bind('onDocumentPageSet', function (e, newPageIndex) {
if (docViewerPageFlipViewModel)
docViewerPageFlipViewModel.onDocumentPageSet(newPageIndex);
if (search)
searchViewModel.documentPageSetHandler();
});
docViewer.bind('onDocumentLoadComplete', function (e, data, pdf2XmlWrapper) {
if (docViewerPageFlipViewModel)
docViewerPageFlipViewModel._onDocumentLoaded(data, pdf2XmlWrapper);
var url = data.url;
$("#btnDownload,#btnDownload2").bind({
click: function () {
window.location.href = url;
return false;
}
});
if (embedSource) {
embedSourceViewModel.setGuid(data.guid);
embedSourceViewModel.setFileId(docViewerViewModel.getFileId());
embedSourceViewModel.password(docViewerViewModel.password());
}
if (zooming) {
if (docViewerViewModel.isScrollViewerVisible()) {
zoomViewModel.setFitWidthZoom(docViewerViewModel.getFitWidthZoom());
zoomViewModel.setFitHeightZoom(docViewerViewModel.getFitHeightZoom());
zoomViewModel.setZoomWithoutEvent(docViewerViewModel.zoom());
}
else {
if (docViewerPageFlipViewModel) {
zoomViewModel.setFitWidthZoom(docViewerPageFlipViewModel.getFitWidthZoom());
zoomViewModel.setFitHeightZoom(docViewerPageFlipViewModel.getFitHeightZoom());
zoomViewModel.setZoomWithoutEvent(docViewerPageFlipViewModel.zoom());
}
}
}
if (search) {
searchViewModel.documentLoaded();
}
} .bind(this));
docViewer.bind("layoutChanged.groupdocs", function (e) {
if (zooming) {
if (docViewerViewModel.isScrollViewerVisible()) {
zoomViewModel.setFitWidthZoom(docViewerViewModel.getFitWidthZoom());
zoomViewModel.setFitHeightZoom(docViewerViewModel.getFitHeightZoom());
}
}
});
if (docViewerPageFlip) {
docViewerPageFlip.bind('onPageTurned', function (e, pageIndex) {
if (navigation) {
navigationViewModel.setPageIndex(pageIndex);
}
if (thumbnails) {
thumbnailsViewModel.pageInd(pageIndex);
}
docViewerViewModel.pageInd(pageIndex);
docViewerViewModel.setPageNumerInUrlHash(pageIndex);
});
}
if (search) {
search.bind('onPerformSearch', function (e, value, isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact, useAccentInsensitiveSearch) {
docViewerViewModel.performSearch(value, isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact, useAccentInsensitiveSearch);
});
}
if (navigation) {
navigation.bind('onUpNavigate', function (e, pageIndex) {
if (docViewerPageFlipViewModel)
docViewerPageFlipViewModel.setPage(pageIndex);
docViewerViewModel.setPage(pageIndex);
if (thumbnails) {
thumbnailsViewModel.setPageWithoutEvent(pageIndex);
thumbnailsViewModel.setThumbnailsScroll({ pi: pageIndex, direction: 'up' });
}
} .bind(this));
navigation.bind('onDownNavigate', function (e, pageIndex) {
if (docViewerPageFlipViewModel)
docViewerPageFlipViewModel.setPage(pageIndex);
docViewerViewModel.setPage(pageIndex);
if (thumbnails) {
thumbnailsViewModel.setPageWithoutEvent(pageIndex);
thumbnailsViewModel.setThumbnailsScroll({ pi: pageIndex, direction: 'down' });
}
} .bind(this));
navigation.bind('onSetNavigate', function (e, data) {
if (docViewerPageFlipViewModel)
docViewerPageFlipViewModel.setPage(data.pageIndex);
docViewerViewModel.setPage(data.pageIndex);
if (thumbnails) {
thumbnailsViewModel.setPageWithoutEvent(data.pageIndex);
thumbnailsViewModel.setThumbnailsScroll({ pi: data.pageIndex, direction: data.direction, eventAlreadyRaised: true });
}
} .bind(this));
}
if (zooming) {
zooming.bind('onSetZoom', function (e, value) {
if (docViewerPageFlipViewModel)
docViewerPageFlipViewModel.setZoom(value);
docViewerViewModel.setZoom(value);
if (search) {
searchViewModel.resetButtons();
}
} .bind(this));
zooming.bind(menuClickedEvent, function () {
if (viewTypeMenu)
viewTypeViewModel.showDropDownMenu(false);
});
}
if (thumbnails) {
thumbnails.bind('onSetThumbnails', function (e, index) {
docViewerViewModel.setPage(index);
if (docViewerPageFlipViewModel)
docViewerPageFlipViewModel.setPage(index);
if (navigation) {
navigationViewModel.setPageIndex(index);
}
} .bind(this));
thumbnails.bind('onSetThumbnailsScroll', function (e, index) {
if (navigation) {
navigationViewModel.setPageIndex(index);
}
} .bind(this));
thumbnails.bind('onResizeThumbnails', function (e, viewerLeft) {
docViewerViewModel.resizeViewerElement(viewerLeft);
if (docViewerPageFlipViewModel)
docViewerPageFlipViewModel.resizeViewerElement(viewerLeft);
});
thumbnails.bind('onPageReordered', function (e, oldPosition, newPosition) {
docViewerViewModel.onPageReordered(oldPosition, newPosition);
});
}
if (viewTypeMenu) {
viewTypeMenu.bind(menuClickedEvent, function () {
if (zoomViewModel)
zoomViewModel.showDropDownMenu(false);
});
}
},
thumbnailsCreator: function () {
},
thumbnailsViewModelCreator: function () {
return { set: function () { },
setThumbnailsScroll: function () { },
onProcessPages: function () { },
getThumbnailsPanelWidth: function () { return 0; }
};
}
});
//
// Point class
//
jSaaspose.Point = function (x, y) {
this.x = x || 0;
this.y = y || 0;
}
$.extend(jSaaspose.Point.prototype, {
x: 0,
y: 0,
clone: function () {
return new jSaaspose.Point(this.x, this.y);
},
round: function () {
this.x = Math.round(this.x);
this.y = Math.round(this.y);
return this;
}
});
//
// Rectangle class
//
jSaaspose.Rect = function (x1, y1, x2, y2, normalize) {
this.set(x1, y1, x2, y2, normalize);
}
$.extend(jSaaspose.Rect.prototype, {
topLeft: null,
bottomRight: null,
clone: function () {
return new jSaaspose.Rect(this.topLeft.x, this.topLeft.y, this.bottomRight.x, this.bottomRight.y, false);
},
set: function (x1, y1, x2, y2, normalize) {
if (!this.topLeft) {
this.topLeft = new jSaaspose.Point();
}
if (!this.bottomRight) {
this.bottomRight = new jSaaspose.Point();
}
this.topLeft.x = x1;
this.topLeft.y = y1;
this.bottomRight.x = x2;
this.bottomRight.y = y2;
return (normalize ? this.normalize() : this);
},
add: function (point) {
this.topLeft.x += point.x;
this.topLeft.y += point.y;
this.bottomRight.x += point.x;
this.bottomRight.y += point.y;
return this;
},
subtract: function (point) {
this.topLeft.x -= point.x;
this.topLeft.y -= point.y;
this.bottomRight.x -= point.x;
this.bottomRight.y -= point.y;
return this;
},
scale: function (factor) {
this.topLeft.x *= factor;
this.topLeft.y *= factor;
this.bottomRight.x *= factor;
this.bottomRight.y *= factor;
return this;
},
round: function () {
this.topLeft = this.topLeft.round();
this.bottomRight = this.bottomRight.round();
return this;
},
left: function () {
return this.topLeft.x;
},
top: function () {
return this.topLeft.y;
},
right: function () {
return this.bottomRight.x;
},
bottom: function () {
return this.bottomRight.y;
},
width: function () {
return (this.bottomRight.x - this.topLeft.x);
},
height: function () {
return (this.bottomRight.y - this.topLeft.y);
},
setLeft: function (x) {
this.topLeft.x = x;
},
setTop: function (y) {
this.topLeft.y = y;
},
setRight: function (x) {
this.bottomRight.x = x;
},
setBottom: function (y) {
this.bottomRight.y = y;
},
contains: function (point) {
return (
this.topLeft.x <= point.x && point.x <= this.bottomRight.x &&
this.topLeft.y <= point.y && point.y <= this.bottomRight.y);
},
includes: function (rect) {
return (
this.contains(rect.topLeft) &&
this.contains(rect.bottomRight));
},
intersects: function (rect) {
return !(this.topLeft.x > rect.bottomRight.x ||
this.bottomRight.x < rect.topLeft.x ||
this.topLeft.y > rect.bottomRight.y ||
this.bottomRight.y < rect.topLeft.y);
},
normalize: function () {
if (this.topLeft.x > this.bottomRight.x)
this.bottomRight.x = [this.topLeft.x, this.topLeft.x = this.bottomRight.x][0];
if (this.topLeft.y > this.bottomRight.y)
this.bottomRight.y = [this.topLeft.y, this.topLeft.y = this.bottomRight.y][0];
return this;
}
});
$.ctrl = function (key, callback, args) {
$(document).keydown(function (e) {
if (!args) args = []; // IE barks when args is null
if (e.keyCode == key.charCodeAt(0) && e.ctrlKey) {
callback.apply(this, args);
return true;
}
});
};
(function ($, undefined) {
$.widget("ui.dvselectable", $.ui.mouse, {
customArea: [],
search: null,
lasso: null,
pages: [],
prevProportions: 1,
prevCustomTemplateProportions: 1,
searchProportions: 1,
selectedRowsCoordinates: [],
highlightPaneContainer: null,
highlightSearchPaneContainer: null,
buttonPaneContainer: null,
template: "<div id={0} class='highlight selection-highlight' style='top: {1}px; height: {2}px; width: {3}px; left: {4}px;'></div>",
searchTemplate: "<div id={0} class='highlight search-highlight' style='top: {1}px; height: {2}px; width: {3}px; left: {4}px;'></div>",
addTemplate: "<div id={0} class='{3}' style='top: {1}px; left: {2}px;' index='{4}'></div>",
cAreaPageIndex: 0,
cAreaFieldIndex: 0,
annotationContainer: "<div id={0} style='position:relative'>{1}</div>",
annotationTemplate: "<div class='highlight annotation-highlight' style='top: {0}px; height: {1}px; width: {2}px; left: {3}px;'></div>",
timeouts: [],
flag: 0,
options: {
appendTo: "body",
txtarea: "",
pdf2XmlWrapper: null,
startNumbers: null,
pagesCount: 0,
proportion: 1,
cancel: ':input,option,.comment',
bookLayout: false,
docSpace: '',
highlightColor: null
},
_initialized: false,
_textSelectionByCharModeEnabled: false,
_canvasOffset: null,
_canvasScroll: null,
_mouseStartPos: null,
_selectionInfo: {
position: -1,
length: 0
},
_enabled: true,
SelectionModes: { SelectText: 0, SelectRectangle: 1, SelectTextToStrikeout: 2, ClickPoint: 3, TrackMouseMovement: 4, DoNothing: 5 },
_mode: null,
_lassoCssElement: null,
rightMargin: 35,
parentElement: null,
_viewModel: null,
selectionCounter: 0,
_create: function () {
this._initialized = false;
this.initCanvasOffset();
if (!this.options.initializeStorageOnly) {
this.dragged = false;
if (this.options.preventTouchEventsBubbling) {
function preventEventBubble(event) {
event.preventBubble();
}
this.element.bind({
touchstart: preventEventBubble,
touchmove: preventEventBubble,
touchend: preventEventBubble
});
}
this._mouseInit();
this.helper = $("<div class='ui-selectable-helper'></div>");
this.createEventHandlers();
this.setMode(this.SelectionModes.SelectText);
this.pagePrefix = this.options.pagePrefix;
}
},
createEventHandlers: function () {
var self = this;
$.ctrl('C', function () {
var activeElement = $(document.activeElement);
var activeElementId = activeElement.attr('id');
var activeElementName = activeElement.attr('name');
if ((activeElementId !== self.options.txtarea.attr('id') || activeElementName !== self.options.txtarea.attr('name'))
&& (activeElement.is("input") || activeElement.is("textarea")))
return;
self.options.txtarea.focus().select();
//$('#' + self.options.txtarea).focus().select();
});
$(self.element).bind({
click: function (e) {
return self.mouseClickHandler(e);
//return false;
//self.initHighlightPaneContainer();
//self.clearShown();
}
});
},
_init: function () {
this._initialized = false;
if (this.options.pdf2XmlWrapper == null)
return;
this.initStorage();
this.search = [];
if (this.options.initStorageOnMouseStart)
this._initialized = false;
},
destroy: function () {
this._mouseDestroy();
return this;
},
initStorage: function () {
if (this._initialized)
return;
this._initialized = true;
var locations;
if (this.options.useVirtualScrolling) {
this.pageLocations = $.map(this.options.pageLocations,
function (page) {
return new jSaaspose.Point(page.left, page.top());
});
}
else
this.pageLocations = this._getPageLocations();
locations = this.pageLocations;
if (this.options.pdf2XmlWrapper != null) {
if (this.options.bookLayout /*|| this.options.useVirtualScrolling*/) {
this.pages = this.options.pdf2XmlWrapper.getPages(this.options.proportion, locations,
this.options.startNumbers.start - 1, this.options.startNumbers.end - 1, this.options.useVirtualScrolling, !this.options.bookLayout);
}
else {
this.pages = this.options.pdf2XmlWrapper.getPages(this.options.proportion, locations, 0, this.options.pagesCount - 1, undefined, true);
}
}
},
initCanvasOffset: function () {
this.parentElement = this.options.docSpace.parent();
var offset = this.element.parent().offset();
var offsetX = offset.left, offsetY = offset.top;
if (this.options.bookLayout)
offsetY = this.parentElement.offset().top;
this._canvasOffset = new jSaaspose.Point(offsetX, offsetY);
},
getPages: function () {
this.initStorage();
return this.pages;
},
_getPageLocations: function () {
var self = this;
var docSpaceId = this.options.docSpace.attr("id");
var imagesSelector = ".page-image";
var images = this.element.find(imagesSelector);
if (this.options.bookLayout) {
images = images.filter("[id='" + docSpaceId + "-img-" + this.options.startNumbers.start.toString() +
"'],[id='" + docSpaceId + "-img-" + this.options.startNumbers.end.toString() + "']");
}
this._canvasScroll = this.getCanvasScroll();
return $.map(images, function (img) {
var imgJquery = $(img);
var x = imgJquery.offset().left - self._canvasOffset.x + self._canvasScroll.x;
//var y = (self.options.bookLayout ? 0 : ($(img).offset().top - self._canvasOffset.y + self._canvasScroll.y));
var y = (self.options.bookLayout ? 0 : (imgJquery.offset().top - self.element.offset().top));
return new jSaaspose.Point(x, y);
});
},
getCanvasScroll: function () {
if (this.options.bookLayout)
return new jSaaspose.Point(this.parentElement.scrollLeft(), this.parentElement.scrollTop());
else
return new jSaaspose.Point(this.element.parent().scrollLeft(), this.element.parent().scrollTop());
},
clearSelection: function () {
this.element.find(".selection-highlight:not(.static)").remove();
},
clearSelectionOnPage: function (pageNumber) {
this.element.find("#" + this.pagePrefix + (pageNumber + 1) + " > .highlight-pane > .selection-highlight:not(.static)").remove();
},
_mouseCapture: function (event) {
var page = null;
this._canvasScroll = this.getCanvasScroll();
this._mouseStartPos = new jSaaspose.Point(
event.pageX - this._canvasOffset.x + this._canvasScroll.x,
event.pageY - this._canvasOffset.y + this._canvasScroll.y);
return (this._mode != this.SelectionModes.DoNothing &&
this._findPageAt(this._mouseStartPos) != null)
},
_mouseStart: function (event) {
this.options.docSpace.focus();
this.initStorage();
this.clearSelection();
if (this._mode == this.SelectionModes.DoNothing) {
return false;
}
this.selectionCounter++;
//this._canvasScroll = new jSaaspose.Point(this.parentElement.scrollLeft(), this.parentElement.scrollTop());
this._canvasScroll = this.getCanvasScroll();
if (this.options.bookLayout)
this._canvasScroll.y += this.parentElement.parent().scrollTop();
if (this.checkMouseIsInEdgeInBookMode(this._mouseStartPos.x, this._mouseStartPos.y))
return false;
if (this._mode == this.SelectionModes.TrackMouseMovement) {
var top = this._mouseStartPos.y;
var page = this.findPageAtVerticalPosition(top);
var pageNumber = parseInt(page.pageId) - 1;
this.element.trigger("onMouseMoveStarted", [pageNumber, { left: this._mouseStartPos.x, top: top }]);
} else {
this.element.append(this.helper);
this.helper.css({
"left": this._mouseStartPos.x,
"top": this._mouseStartPos.y,
"width": 0,
"height": 0
});
}
this.options.txtarea.val("");
this.lasso = new jSaaspose.Rect();
},
_mouseDrag: function (event) {
if (this._mode == this.SelectionModes.DoNothing || this.checkMouseIsInEdgeInBookMode(this._mouseStartPos.x, this._mouseStartPos.y))
return false;
var x1 = this._mouseStartPos.x, y1 = this._mouseStartPos.y,
x2 = event.pageX - this._canvasOffset.x + this._canvasScroll.x,
y2 = event.pageY - this._canvasOffset.y + this._canvasScroll.y;
var currentX = x2,
currentY = y2;
if (this._findPageAt(new jSaaspose.Point(currentX, currentY)) != this._findPageAt(new jSaaspose.Point(x1, y1))) {
return false;
};
if (!this._findPageAt(new jSaaspose.Point(currentX, currentY)))
return false;
this.dragged = true;
if (x1 > x2) { var tmp = x2; x2 = x1; x1 = tmp; }
if (y1 > y2) { var tmp = y2; y2 = y1; y1 = tmp; }
this.lasso.set(x1, y1, x2, y2);
if (this._mode != this.SelectionModes.ClickPoint && this._mode != this.SelectionModes.TrackMouseMovement) {
this.helper.css({ left: x1, top: y1, width: this.lasso.width(), height: this.lasso.height() });
}
this.findSelectedPages(false, null, undefined, this.options.highlightColor);
this.element.trigger("onMouseDrag", [{ left: currentX, top: currentY }]);
return false;
},
_mouseStop: function (event) {
if (this._mode == this.SelectionModes.DoNothing)
return false;
this.helper.remove();
var page = this._findPageAt(this.lasso.topLeft) || this.pages[0];
if (typeof (page) === "undefined") return false;
var pageOffset;
var pageNumber = parseInt(page.pageId) - 1;
var originalRects = null;
if (pageNumber < 0) return false;
if (this._mode == this.SelectionModes.SelectText || this._mode == this.SelectionModes.SelectTextToStrikeout) {
if (!this.dragged) {
return false;
}
var self = this;
this.dragged = false;
var rects = self._getDocumentHighlightRects();
if (!rects || rects.length == 0) {
return false;
}
var text = '';
var bounds = (this.options.storeAnnotationCoordinatesRelativeToPages ?
this.convertRectToRelativeToPageUnscaledCoordinates(this.lasso) :
this.convertRectToAbsoluteCoordinates(this.lasso));
var top = bounds.top(), bottom = bounds.bottom();
bounds = rects[0].originalRect;
var left = bounds.left(), right = bounds.right();
var highestTop = bounds.top();
var lowestBottom = bounds.bottom();
var pos = rects[0].position, len = rects[rects.length - 1].position + rects[rects.length - 1].length - pos;
originalRects = [];
for (var i = 0; i < rects.length; i++) {
text += rects[i].text;
text += ((i > 0 && (rects[i - 1].page != rects[i].page || rects[i - 1].row != rects[i].row)) ? '\r\n' : ' ');
bounds = rects[i].originalRect;
originalRects.push(bounds);
left = Math.min(left, bounds.left());
right = Math.max(right, bounds.right());
highestTop = Math.min(highestTop, bounds.top());
lowestBottom = Math.max(lowestBottom, bounds.bottom());
}
var scale = this.options.proportion;
if (this.options.storeAnnotationCoordinatesRelativeToPages) {
top = Math.min(highestTop, top);
bottom = Math.max(lowestBottom, bottom);
}
else {
pageOffset = pageNumber * this.options.pageHeight;
pageOffset /= scale;
top = Math.max(pageOffset + highestTop, top);
bottom = Math.min(pageOffset + lowestBottom, bottom);
}
var selectionBounds = new jSaaspose.Rect(left, top, right, bottom);
var selectionBoundsScaled = selectionBounds.clone();
this.options.txtarea.val($.trim(text));
}
switch (this._mode) {
case this.SelectionModes.SelectText:
this.element.trigger('onTextSelected', [pageNumber, selectionBoundsScaled, pos, len, this.selectionCounter, originalRects]);
break;
case this.SelectionModes.SelectTextToStrikeout:
this.element.trigger('onTextToStrikeoutSelected', [pageNumber, selectionBoundsScaled, pos, len, this.selectionCounter, originalRects]);
break;
case this.SelectionModes.SelectRectangle:
var selectedRectangle;
if (this.options.storeAnnotationCoordinatesRelativeToPages) {
selectedRectangle = this.convertRectToRelativeToPageUnscaledCoordinates(this.lasso, this._mouseStartPos);
}
else {
selectedRectangle = this.convertRectToAbsoluteCoordinates(this.lasso, this._mouseStartPos);
}
this.element.trigger('onRectangleSelected', [pageNumber, selectedRectangle]);
break;
case this.SelectionModes.ClickPoint:
this.mouseClickHandler(event);
break;
case this.SelectionModes.TrackMouseMovement:
$(this.element).trigger('onMouseMoveStopped', []);
break;
default:
break;
}
return false;
},
mouseClickHandler: function (event) {
//*********************
//Fixed ANNOTATION-1107
if (event.toElement == undefined) {
event.toElement = event.target;
}
if (event.target.className != "doc_text_area_text mousetrap") {
this.options.docSpace.focus();
}
//*********************
//*********************
//Fixed ANNOTATION-970
if (this._mode == this.SelectionModes.SelectText) {
var widgetTooltipClicked = false;
if (event && event.originalEvent && event.originalEvent.path) {
$.each(event.originalEvent.path, function(index, val) {
if (val.className == "widget-tooltip") {
widgetTooltipClicked = true;
}
});
}
if (widgetTooltipClicked) {
this.destroy();
this._enabled = false;
} else if (this._enabled == false) {
this.destroy();
$(this.element).unbind();
this._enabled = true;
this._create();
}
}
//************************
if (this._mode == this.SelectionModes.ClickPoint) {
this.initStorage();
this._canvasScroll = this.getCanvasScroll();
var lastX = event.pageX - this._canvasOffset.x + this._canvasScroll.x;
var lastY = event.pageY - this._canvasOffset.y + this._canvasScroll.y;
var lastPoint = new jSaaspose.Rect(lastX, lastY, lastX, lastY);
var page = this._findPageAt(lastPoint.topLeft);
if (!page)
return true;
var pageNumber = parseInt(page.pageId) - 1;
if (this.options.storeAnnotationCoordinatesRelativeToPages) {
lastPoint = this.convertRectToRelativeToPageUnscaledCoordinates(lastPoint);
}
else {
lastPoint = this.convertRectToAbsoluteCoordinates(lastPoint);
}
this.element.trigger('onPointClicked', [pageNumber, lastPoint]);
return false;
}
return true;
},
checkMouseIsInEdgeInBookMode: function (mouseX, mouseY) {
var elementWidth = this.element.width();
var elementHeight = this.element.height();
var edgeWidth = 100, edgeHeight = 100;
if (this.options.bookLayout &&
((mouseX > elementWidth - edgeWidth && mouseY < edgeHeight) ||
(mouseX > elementWidth - edgeWidth && mouseY > elementHeight - edgeHeight) ||
(mouseX < edgeWidth && mouseY < edgeHeight) ||
(mouseX < edgeWidth && mouseY > elementHeight - edgeHeight)
))
return true;
else
return false;
},
convertRectToAbsoluteCoordinates: function (rect, position) {
this.initStorage();
var selectedRectangle = rect.clone();
var scale = this.options.proportion;
var page = null;
if (position)
page = this._findPageNearby(position);
else
page = this._findPageNearby(selectedRectangle.topLeft);
selectedRectangle.subtract(page.rect.topLeft);
var pageNumber = parseInt(page.pageId) - 1;
var pageOffset = pageNumber * this.options.pageHeight;
pageOffset /= scale;
selectedRectangle.scale(1 / scale);
selectedRectangle.add(new jSaaspose.Point(0, pageOffset));
return selectedRectangle;
},
convertRectToScreenCoordinates: function (rect) {
this.initStorage();
var bounds = rect.clone().scale(this.options.proportion);
if (bounds.top() < 0)
bounds.setTop(0);
var pageHeight = this.options.pageHeight;
var pageNumber = Math.floor(bounds.top() / pageHeight);
bounds.subtract(new jSaaspose.Point(0, pageNumber * pageHeight));
if (this.pages.length != 0)
bounds.add(this.pages[pageNumber].rect.topLeft);
return bounds;
},
convertRectToRelativeToPageUnscaledCoordinates: function (rect, position) {
this.initStorage();
var sourceRectangle = rect.clone();
var scale = this.options.proportion;
var page = null;
if (position)
page = this._findPageNearby(position);
else
page = this._findPageNearby(sourceRectangle.topLeft);
sourceRectangle.subtract(page.rect.topLeft);
sourceRectangle.scale(1 / scale);
return sourceRectangle;
},
convertPageAndRectToScreenCoordinates: function (pageNumber, rect) {
this.initStorage();
var bounds = rect.clone().scale(this.options.proportion);
if (bounds.top() < 0)
bounds.setTop(0);
if (this.pages.length != 0)
bounds.add(this.pages[pageNumber].rect.topLeft);
return bounds;
},
highlightPredefinedArea: function (rect, clickHandler, pageNumber, selectionCounter, color, hoverHandlers) {
this.initStorage();
this.dragged = true;
if (this.options.storeAnnotationCoordinatesRelativeToPages) {
this.lasso = this.convertPageAndRectToScreenCoordinates(pageNumber, rect);
}
else {
this.lasso = this.convertRectToScreenCoordinates(rect);
}
this.selectionCounter++;
var page = this._findPageAt(this.lasso.topLeft) || this.pages[0];
var pageNumbers = this.options.startNumbers;
this.options.startNumbers = { start: parseInt(page.pageId), end: parseInt(page.pageId) };
this.findSelectedPages(true, clickHandler, selectionCounter, color || this.options.highlightColor, hoverHandlers);
this.options.startNumbers = pageNumbers;
this.dragged = false;
if (typeof selectionCounter == "undefined")
return this.selectionCounter;
else {
return selectionCounter;
}
},
unhighlightPredefinedArea: function (rect, deleteStatic, pageNumber, selectionCounter) {
if (this.options.storeAnnotationCoordinatesRelativeToPages) {
this.lasso = this.convertPageAndRectToScreenCoordinates(pageNumber, rect);
}
else {
this.lasso = this.convertRectToScreenCoordinates(rect);
}
var rects = this._getDocumentHighlightRects();
if (!rects || rects.length == 0) {
return;
}
if (typeof selectionCounter == "undefined")
selectionCounter = "";
for (var i = 0; i < rects.length; i++) {
var pageId = rects[i].page + 1;
var rowId = rects[i].row + 1;
//var elementSelector = "#" + this.pagePrefix + pageId + "-highlight-" + rowId;
var elementSelector = "#" + this.pagePrefix + pageId + "-highlight-" + rowId + "-" + selectionCounter;
if (deleteStatic) {
elementSelector += ".static";
}
else {
elementSelector += ":not(.static)";
}
$(elementSelector).remove();
}
},
setVisiblePagesNumbers: function (vPagesNumbers) {
this.options.startNumbers = vPagesNumbers;
},
handleDoubleClick: function (event) {
this.lasso = new jSaaspose.Rect(event.pageX, event.pageY, event.pageX, event.pageY);
this.initStorage();
this.findSelectedPages();
},
initHighlightSearchPaneContainer: function () {
var containers = this._getElementsByClassName('search-pane', document.getElementById(this.options.docSpace.attr('id') + '-pages-container'));
var len = containers.length;
for (var i = len; i--;)
if (containers[i].children.length != 0)
containers[i].innerHTML = '';
this.highlightSearchPaneContainer = containers;
},
initButtonPaneContainer: function () {
var containers = this._getElementsByClassName('button-pane', document.getElementById(this.options.docSpace.attr('id') + '-pages-container'));
var len = containers.length;
for (var i = len; i--;)
if (containers[i].children.length != 0)
containers[i].innerHTML = '';
this.buttonPaneContainer = containers;
},
reInitPages: function (scaleFactor, visiblePagesNumbers, scrollPosition, pageHeight, pageLocations) {
this._initialized = false;
this.options.startNumbers = visiblePagesNumbers;
this.options.proportion = scaleFactor;
this.options.pageHeight = pageHeight;
this.initCanvasOffset();
this.initStorage();
},
changeSelectedRowsStyle: function (proportions) {
this.changeCustomAreasStyle(proportions);
this.changeSearchStyle(proportions);
var highlights = this.element.find('.highlight-pane .highlight');
var scale = proportions / this.options.proportion;
this.options.proportion = proportions;
$.each(highlights, function () {
var pos = $(this).position();
$(this).css({
top: pos.top * scale,
left: pos.left * scale,
width: $(this).width() * scale,
height: $(this).height() * scale
});
});
},
performSearch: function (originalSearchValue, zoomValue, isCaseSensitive,
searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact, useAccentInsensitiveSearch) {
var searchValue;
var phraseIsInDoubleQuotes = false;
if (isCaseSensitive)
searchValue = originalSearchValue;
else
searchValue = originalSearchValue.toLowerCase();
if (searchForSeparateWords && treatPhrasesInDoubleQuotesAsExact) {
var trimmedText = searchValue.replace(/^[\r\n\s]+|[\r\n\s]+$/g, "");
if (trimmedText.length >= 2 && trimmedText[0] == '"' && trimmedText[trimmedText.length - 1] == '"') {
searchForSeparateWords = false;
searchValue = trimmedText.substr(1, trimmedText.length - 2);
searchValue = searchValue.replace(/^[\r\n\s]+|[\r\n\s]+$/g, "");
phraseIsInDoubleQuotes = true;
}
}
this.search.length = 0;
this.initHighlightSearchPaneContainer();
if (searchValue == '')
return -1;
this.searchProportions = zoomValue;
var pages = this.pages;
var pagesLen = pages.length;
var pageWords = [], pageWordsUnscaled = [];
var searchWords = [];
var searchWordsLen, wordsLen;
var startIndex, endIndex, wordId;
var seachCountItem = 0;
var startingCharacterInWordNum;
var searchValueWithAccentedWords;
var row, rowText;
if (useAccentInsensitiveSearch) {
searchValueWithAccentedWords = new RegExp(window.jGroupdocs.stringExtensions.getAccentInsensitiveRegexFromString(searchValue));
}
var r;
if (searchForSeparateWords) {
searchWords = this.getWords(searchValue);
if (useAccentInsensitiveSearch) {
var wordsWithAccentedChars = new Array();
for (var wordNum = 0; wordNum < words.length; wordNum++) {
wordsWithAccentedChars.push(
new RegExp(window.jGroupdocs.stringExtensions.getAccentInsensitiveRegexFromString(searchWords[wordNum])));
}
searchWords = wordsWithAccentedChars;
}
searchWordsLen = searchWords.length;
}
var currentImageWidth;
if (this.options.searchPartialWords)
currentImageWidth = this.options.proportion * this.options.pdf2XmlWrapper.getPageSize().width;
for (var pageId = 0; pageId < pagesLen; pageId++) {
var rows = pages[pageId].rows;
var rowsLen = rows.length;
var PageId = pageId + 1;
var rowWords, rowWordsLen;
var rowPositionsInText = new Array();
var summaryText = "";
var searchValueRemainderLength = 0;
var searchValueRemainder = null;
if (!searchForSeparateWords && this.options.searchPartialWords) {
for (var rowNum = 0; rowNum < rowsLen; rowNum++) {
row = rows[rowNum];
rowPositionsInText.push(summaryText.length);
if (isCaseSensitive)
rowText = row.text;
else
rowText = row.text.toLowerCase();
summaryText += $.trim(rowText);
if (rowNum < rowsLen - 1)
summaryText += " ";
}
}
for (var rowId = 0; rowId < rowsLen; rowId++) {
var left = 0, right = 0;
row = rows[rowId];
if (isCaseSensitive)
rowText = row.text;
else
rowText = row.text.toLowerCase();
if (searchForSeparateWords) {
if (searchWordsLen == 0)
break;
rowWords = row.words;
rowWordsLen = rowWords.length;
var rowWordIndex, searchWordIndex;
for (rowWordIndex = 0; rowWordIndex < rowWordsLen; rowWordIndex++) {
for (searchWordIndex = 0; searchWordIndex < searchWordsLen; searchWordIndex++) {
var searchWord = $.trim(searchWords[searchWordIndex]);
var rowWord = rowWords[rowWordIndex].text;
if (!isCaseSensitive) {
searchWord = searchWord.toLowerCase();
rowWord = rowWord.toLowerCase();
}
startingCharacterInWordNum = rowWord.indexOf(searchWord);
if (startingCharacterInWordNum != -1) {
var characterCoordinates = this.options.pdf2XmlWrapper.getRowCharacterCoordinates(pageId, rowId);
var firstWordLeft = rowWords[rowWordIndex].originalRect.left();
var firstWordStartPosition = 0;
for (var charNum = 0; charNum < characterCoordinates.length; charNum++) {
var characterCoordinate = characterCoordinates[charNum];
if (Math.round(characterCoordinate) >= Math.round(firstWordLeft)) {
firstWordStartPosition = charNum;
break;
}
}
var searchStartPosition = firstWordStartPosition + startingCharacterInWordNum;
if (searchStartPosition < characterCoordinates.length) {
left = characterCoordinates[searchStartPosition];
}
else
left = firstWordLeft;
if (left < firstWordLeft || left > wordRight)
left = firstWordLeft;
searchEndPosition = searchStartPosition + searchWord.length;
if (searchEndPosition >= characterCoordinates.length)
right = row.originalRect.right();
else
right = characterCoordinates[searchEndPosition];
r = rowWords[rowWordIndex].rect.clone();
r.subtract(rowWords[rowWordIndex].pageLocation);
var scale = currentImageWidth / pages[pageId].originalWidth;
var scaledLeft = left * scale;
var scaledRight = right * scale;
r.setLeft(scaledLeft);
r.setRight(scaledRight);
pageWords.push(r);
r = rowWords[rowWordIndex].originalRect.clone();
r.setLeft(left);
r.setRight(right);
pageWordsUnscaled.push(r);
}
}
}
} // end: if (searchForSeparateWords)
else {
if (this.options.searchPartialWords) {
var rowPositionInText = rowPositionsInText[rowId];
var rowEndPositionInText;
if (rowId < rowsLen - 1)
rowEndPositionInText = rowPositionsInText[rowId + 1];
else
rowEndPositionInText = summaryText.length;
}
var textPosition;
var searchValueForThisRow;
if (useAccentInsensitiveSearch) {
searchValueForThisRow = searchValueRemainder ? searchValueRemainder : searchValueWithAccentedWords;
textPosition = summaryText.search(searchValueForThisRow, rowPositionInText);
}
else {
searchValueForThisRow = searchValueRemainder ? searchValueRemainder : searchValue;
textPosition = summaryText.indexOf(searchValueForThisRow, rowPositionInText);
}
if (textPosition < rowPositionInText || textPosition >= rowEndPositionInText)
textPosition = -1;
else
textPosition -= rowPositionInText;
while (textPosition != -1) {
rowWords = row.words;
if (this.options.searchPartialWords) {
var spaceCountRegex = /\s/g;
var initialSubstring = rowText.substring(0, textPosition);
var searchValueThatOverlapsRowLength = rowText.length - textPosition;
var searchValueThatOverlapsRow = searchValueForThisRow.substr(0, searchValueThatOverlapsRowLength);
searchValueRemainderLength = searchValueForThisRow.length - searchValueThatOverlapsRowLength;
if (searchValueRemainderLength > 0)
searchValueRemainder = searchValueForThisRow.substr(searchValueThatOverlapsRowLength + 1); // +1 for space between words
else {
searchValueRemainder = null;
}
var initialWords = initialSubstring.match(spaceCountRegex);
var overlappedWords = searchValueThatOverlapsRow.match(spaceCountRegex);
var firstWordNumber = 0, overlappedWordCount = 0;
if (initialWords)
firstWordNumber = initialWords.length;
if (overlappedWords)
overlappedWordCount = overlappedWords.length;
var lastWordNumber = firstWordNumber + overlappedWordCount;
var characterCoordinates = this.options.pdf2XmlWrapper.getRowCharacterCoordinates(pageId, rowId);
var firstWordLeft = rowWords[firstWordNumber].originalRect.left();
var lastWordLeft = rowWords[lastWordNumber].originalRect.left();
var wordRight = rowWords[lastWordNumber].originalRect.right();
var rowRight = row.originalRect.right();
startingCharacterInWordNum = initialSubstring.length - initialSubstring.lastIndexOf(" ") - 1;
var firstWordStartPosition = 0, lastWordStartPosition = 0;
var foundFirstWordStartPosition = false;
for (var charNum = 0; charNum < characterCoordinates.length; charNum++) {
var characterCoordinate = characterCoordinates[charNum];
if (!foundFirstWordStartPosition && Math.round(characterCoordinate) >= Math.round(firstWordLeft)) {
firstWordStartPosition = charNum;
foundFirstWordStartPosition = true;
}
if (Math.round(characterCoordinate) >= Math.round(lastWordLeft)) {
lastWordStartPosition = charNum;
break;
}
}
var searchStartPosition = firstWordStartPosition + startingCharacterInWordNum;
if (searchStartPosition < characterCoordinates.length) {
left = characterCoordinates[searchStartPosition];
}
else
left = firstWordLeft;
if (left < firstWordLeft || left > wordRight)
left = firstWordLeft;
var lastSpacePosition = searchValueThatOverlapsRow.lastIndexOf(" ");
var lastWordOfSearchPhrase = searchValueThatOverlapsRow.substring(lastSpacePosition + 1, searchValueThatOverlapsRow.length);
var searchEndPosition;
if (firstWordNumber == lastWordNumber)
searchEndPosition = searchStartPosition + searchValueThatOverlapsRow.length;
else
searchEndPosition = lastWordStartPosition + lastWordOfSearchPhrase.length;
var lastWordMatches = true;
if (searchEndPosition < characterCoordinates.length) {
var lastWordText = rowWords[lastWordNumber].text.toLowerCase();
if (lastWordText.substring(lastWordText.length - lastWordOfSearchPhrase.length, lastWordText.length) == lastWordOfSearchPhrase)
right = wordRight;
else {
right = characterCoordinates[searchEndPosition];
lastWordMatches = false;
}
}
else
right = rowRight;
if (right < left)
right = rowRight;
if (!treatPhrasesInDoubleQuotesAsExact || !phraseIsInDoubleQuotes || lastWordMatches) {
r = rowWords[firstWordNumber].rect.clone();
r.subtract(rowWords[firstWordNumber].pageLocation);
var scale = currentImageWidth / pages[pageId].originalWidth;
var scaledLeft = left * scale;
var scaledRight = right * scale;
r.setLeft(scaledLeft);
r.setRight(scaledRight);
pageWords.push(r);
r = rowWords[firstWordNumber].originalRect.clone();
r.setLeft(left);
r.setRight(right);
pageWordsUnscaled.push(r);
}
if (searchValueRemainderLength <= 0) {
if (useAccentInsensitiveSearch)
searchValueForThisRow = searchValueWithAccentedWords;
else
searchValueForThisRow = searchValue;
}
textPosition = rowText.indexOf(searchValueForThisRow, textPosition + searchValue.length);
}
else {
searchWords = this.getWords(searchValue);
searchWordsLen = searchWords.length;
if (searchWordsLen == 0)
break;
rowWordsLen = rowWords.length;
if (searchWordsLen == 1) {
for (wordId = 0; wordId < rowWordsLen; wordId++) {
if (rowWords[wordId].text.toLowerCase() == $.trim(searchWords[0].toLowerCase())) {
r = rowWords[wordId].rect.clone();
r.subtract(rowWords[wordId].pageLocation);
pageWords.push(r);
}
}
}
else {
startIndex = 0;
endIndex = searchWordsLen - 1;
for (wordId = 0; wordId < rowWordsLen; wordId++) {
if (rowWords[wordId].text.toLowerCase() == $.trim(searchWords[startIndex].toLowerCase())) {
r = rowWords[wordId].rect.clone();
r.subtract(rowWords[wordId].pageLocation);
r.setRight(r.left() + rowWords[wordId + endIndex].rect.right() - rowWords[wordId].rect.left());
pageWords.push(r);
}
}
}
textPosition = -1;
}
}
}
}
if (pageWords.length > 0) {
this.search.push({
PageId: PageId, pageWords: pageWords.slice(0),
pageWordsUnscaled: pageWordsUnscaled.slice(0)
});
seachCountItem += pageWords.length;
pageWords.length = 0;
pageWordsUnscaled.length = 0;
}
}
this.highlightSearch(null, null);
return seachCountItem;
},
getWords: function (phrase) {
var words = $.map(phrase.split(' '),
function (val, index) {
if (val != '') {
return val;
}
});
return words;
},
highlightSearch: function (startPage, endPage) {
if (!this.search)
return;
var data = this.search;
this.initHighlightSearchPaneContainer();
for (var i = 0; i < data.length; i++) {
var pageId = data[i].PageId;
if (startPage === null || endPage === null ||
(pageId - 1 >= startPage && pageId - 1 <= endPage)) {
var pageWords = data[i].pageWords;
for (var j = 0; j < pageWords.length; j++) {
var highlightElement = window.jGroupdocs.stringExtensions.format(this.searchTemplate, this.pagePrefix + pageId + "-search-highlight-" + j, pageWords[j].top(), pageWords[j].height(), pageWords[j].width(), pageWords[j].left());
$('#' + this.pagePrefix + pageId + ' div.search-pane').append(highlightElement);
}
}
}
},
changeSearchStyle: function (proportions) {
if (this.options.useVirtualScrolling || this.search.length == 0)
return;
this.initHighlightSearchPaneContainer();
var search = this.search;
var dif = 0;
var len = search.length;
var searchProportions = this.searchProportions;
var containers = this.highlightSearchPaneContainer;
for (var pageIndex = 0; pageIndex < len; pageIndex++) {
var result = '';
var pageId = search[pageIndex].PageId;
var pageWords = search[pageIndex].pageWords;
var pageWordsLen = pageWords.length;
for (var wordIndex = 0; wordIndex < pageWordsLen; wordIndex++) {
var w = Math.round(Math.round(pageWords[wordIndex].width() / searchProportions) * proportions);
var h = Math.round(Math.round(pageWords[wordIndex].height() / searchProportions) * proportions);
var t = Math.round(Math.round(pageWords[wordIndex].top() / searchProportions) * proportions);
var l = Math.round(((pageWords[wordIndex].left() - dif) / searchProportions) * proportions + dif);
var searchElement = window.jGroupdocs.stringExtensions.format(this.searchTemplate, this.pagePrefix + pageId + "-search-highlight-" + wordIndex, t, h, w, l);
result += searchElement;
}
containers[pageId - 1].innerHTML = result;
}
},
recalculateSearchPositions: function (proportions) {
if (!this.options.useVirtualScrolling || this.search.length == 0)
return;
this.initHighlightSearchPaneContainer();
var search = this.search;
var len = search.length;
for (var pageIndex = 0; pageIndex < len; pageIndex++) {
var searchPage = search[pageIndex];
var pageWordsUnscaled = searchPage.pageWordsUnscaled;
var pageWordsLen = pageWordsUnscaled.length;
var w, h, t, l;
for (var wordIndex = 0; wordIndex < pageWordsLen; wordIndex++) {
l = Math.round(pageWordsUnscaled[wordIndex].left() * proportions);
w = Math.round(pageWordsUnscaled[wordIndex].width() * proportions);
t = Math.round(pageWordsUnscaled[wordIndex].top() * proportions);
h = Math.round(pageWordsUnscaled[wordIndex].height() * proportions);
searchPage.pageWords[wordIndex].set(l, t, l + w, t + h);
}
}
},
clearAllTimeOuts: function () {
var timeouts = this.timeouts;
var len = timeouts.length;
if (len > 0) {
for (var i = len; i--;) {
clearTimeout(timeouts[i]);
}
timeouts = [];
}
},
_getElementsByClassName: function (classname, node) {
if (!node) node = document.getElementsByTagName("body")[0];
var a = [];
var re = new RegExp('\\b' + classname + '\\b');
var els = node.getElementsByTagName("*");
for (var i = 0, j = els.length; i < j; i++)
if (re.test(els[i].className)) a.push(els[i]);
return a;
},
highlightTemplateAreas: function (data, proportion) {
this.customArea = $.extend(true, [], data);
this.changeCustomAreasStyle(proportion);
},
changeCustomAreasStyle: function (proportions) {
if (typeof (this.customArea) === "undefined") {
return;
}
if (this.customArea.length == 0)
return;
//this.prevCustomTemplateProportions
var self = this;
var area = this.customArea;
var dif = 31;
var len = area.length;
$('#' + this.options.docSpace.attr('id') + '-pages-container .custom-pane').html('');
var pageIndex = 0;
var result = '';
(function changeCustomAreasStyleAsync() {
var fields = area[pageIndex].fields;
var fieldsLen = fields.length;
var pageId = area[pageIndex].PageId;
for (var fieldsIndex = 0; fieldsIndex < fieldsLen; fieldsIndex++) {
var w = Math.round(Math.round(fields[fieldsIndex].Width) * proportions);
var h = Math.round(Math.round(fields[fieldsIndex].Height) * proportions);
var t = Math.round(Math.round(fields[fieldsIndex].Y) * proportions);
var l = Math.round(((fields[fieldsIndex].X - dif)) * proportions + dif);
var extraStyles = (self.cAreaPageIndex == pageIndex && self.cAreaFieldIndex == fieldsIndex ? 'border-color:blue' : '');
result += "<div id=" + this.pagePrefix + pageIndex + "-custom-highlight-" + fieldsIndex + " index=" + pageIndex + "/" + fieldsIndex + " class='input-overlay1' style='position:absolute; cursor:pointer; padding: 0px; top: " + t + "px; height: " + h + "px; width: " + w + "px; left: " + l + "px;" + extraStyles + "'></div>";
var customAreaHtml = window.jGroupdocs.stringExtensions.format(self.addTemplate, this.pagePrefix + pageIndex + "-custom-check-" + fieldsIndex, t - 5, l + w - 8, fields[fieldsIndex].iconType == 1 ? "selection-check" : "selection-del", pageIndex + "/" + fieldsIndex);
result += customAreaHtml;
//result += self.addTemplate.format(this.pagePrefix + pageIndex + "-custom-check-" + fieldsIndex, t - 5, l + w - 8, fields[fieldsIndex].iconType == 1 ? "selection-check" : "selection-del", pageIndex + "/" + fieldsIndex);
}
++pageIndex;
var nextPageId = (pageIndex < len ? area[pageIndex].PageId : -1);
if (result != '' && nextPageId != pageId) {
$('#' + this.pagePrefix + pageId + ' .custom-pane').html(result);
self.bindCustomHandler(pageId);
result = '';
}
if (pageIndex < len) {
setTimeout(changeCustomAreasStyleAsync, 0);
}
})();
},
bindCustomHandler: function (pageId) {
var self = this;
$("#" + this.pagePrefix + pageId + " div.input-overlay1, #" + this.pagePrefix + pageId + " div.selection-check, #" + this.pagePrefix + pageId + " div.selection-del").bind({
click: function () {
var index = $(this).attr('index');
var dvViewModel = $('#doc-space').docAssemblyViewer('getViewModel');
if (typeof (index) !== "undefined") {
var indexArray = index.split("/");
var pageIndex = indexArray[0];
var fieldIndex = indexArray[1];
self.cAreaPageIndex = pageIndex;
self.cAreaFieldIndex = fieldIndex;
dvViewModel.moveTo({ groupIndex: parseInt(pageIndex), fieldIndex: parseInt(fieldIndex) });
return false;
}
}
});
$("#" + this.pagePrefix + pageId + " div.input-overlay1").bind({
mouseover: function (e) {
var index = $(this).attr('index');
var dvViewModel = $('#doc-space').docAssemblyViewer('getViewModel');
if (typeof (index) !== "undefined") {
var indexArray = index.split("/");
var pageIndex = indexArray[0];
var fieldIndex = indexArray[1];
dvViewModel.mouseover(e, { groupIndex: parseInt(pageIndex), fieldIndex: parseInt(fieldIndex) });
}
},
mouseout: function (e) {
var index = $(this).attr('index');
var dvViewModel = $('#doc-space').docAssemblyViewer('getViewModel');
if (typeof (index) !== "undefined") {
var indexArray = index.split("/");
var pageIndex = indexArray[0];
var fieldIndex = indexArray[1];
dvViewModel.mouseout(e, { groupIndex: parseInt(pageIndex), fieldIndex: parseInt(fieldIndex) });
}
}
});
},
setCustomAreaIndex: function (data) {
var pageIndex = data.pageIndex;
var fieldIndex = data.fieldIndex;
this.cAreaPageIndex = pageIndex;
this.cAreaFieldIndex = fieldIndex;
},
changeTemplateAreaIcon: function (data) {
var customArea = this.customArea;
var fields = customArea[data.pageIndex].fields;
var elementIdTemplate = this.pagePrefix + "{0}-custom-check-{1}";
var elementId = window.jGroupdocs.stringExtensions.format(elementIdTemplate, data.pageIndex, data.fieldIndex);
//var elementId = elementIdTemplate.format(data.pageIndex, data.fieldIndex);
$('#' + elementId).attr('class', data.iconType == 1 ? "selection-check" : "selection-del");
fields[data.fieldIndex].iconType = data.iconType;
},
findSelectedPages: function (isStatic, clickHandler, selectionCounter, color, hoverHandlers) {
if (this._mode != this.SelectionModes.SelectText && this._mode != this.SelectionModes.SelectTextToStrikeout) {
return;
}
if (typeof selectionCounter == "undefined")
selectionCounter = this.selectionCounter;
var rects = this._getDocumentHighlightRects(selectionCounter);
if (!rects || rects.length == 0) {
return;
}
var highlightPane = null, lastPageId = null;
var template = "<div id='{0}' class='highlight selection-highlight' style='top: {1}px; height: {2}px;'></div>";
for (var i = 0; i < rects.length; i++) {
var bounds = rects[i].bounds;
var pageId = rects[i].page + 1;
var rowId = rects[i].row + 1;
if (highlightPane == null || (lastPageId != null && lastPageId != pageId)) {
highlightPane = this.element.find('#' + this.pagePrefix + pageId + ' div.highlight-pane');
lastPageId = pageId;
}
var pageRowId = this.pagePrefix + pageId + "-highlight-" + rowId + "-" + selectionCounter;
var pageRow = highlightPane.find("#" + pageRowId);
if (pageRow.length == 0) {
var div = $(window.jGroupdocs.stringExtensions.format(template, pageRowId, bounds.top() + 2, bounds.height()));
highlightPane.append(div);
pageRow = div;
}
if (clickHandler) {
var ev = $._data(pageRow.get(0), 'events');
if (!ev || !ev.click) {
pageRow.click(clickHandler);
}
}
if (hoverHandlers) {
var ev = $._data(pageRow.get(0), 'events');
if (!ev || !ev.mouseover)
pageRow.hover(hoverHandlers.mouseenter, hoverHandlers.mouseleave);
}
if (isStatic) {
pageRow.addClass("static");
if (color)
pageRow.css('background-color', color);
}
pageRow.css({ "left": bounds.left() - 1, "width": bounds.width(), "height": bounds.height() });
if (!this.options.bookLayout) {
var page = this.pages[rects[i].page];
var pageRotation = page.rotation;
if (typeof pageRotation == "undefined")
pageRotation = 0;
var perpendicular = pageRotation % 180 > 0;
if (perpendicular)
pageRow.css({ "top": bounds.top() });
}
}
},
_getDocumentHighlightRects: function (selectionCounter) {
var pages = this.pages;
if (pages.length == 0)
return null;
var self = this;
var lasso = self.lasso;
var rects = [];
//var i = self.options.startNumbers.start;
//for (; i <= self.options.startNumbers.end; i++) {
for (var i = 0; i < pages.length; i++) {
if (pages[i] && lasso.intersects(pages[i].rect)) {
var r = self._getPageHighlightRects(i, selectionCounter);
if (r && r.length) {
rects = rects.concat(r);
}
}
}
return rects;
},
_getPageHighlightRects: function (pageIndex, selectionCounter) {
var lasso = this.lasso;
var rows = this.pages[pageIndex].rows;
var rects = [];
for (var i = 0; i < rows.length; i++) {
if (!lasso.intersects(rows[i].rect)) {
if (this.dragged) {
$("#" + this.pagePrefix + (pageIndex + (this.options.bookLayout ? this.options.startNumbers.start : 1)) +
"-highlight-" + (i + 1) + "-" + selectionCounter + ":not(.static)").remove();
}
continue;
}
var rowRect = rows[i].rect;
if ((lasso.left() < rowRect.left() && lasso.bottom() > rowRect.bottom()) ||
(lasso.right() > rowRect.right() && lasso.top() < rowRect.top()) ||
(lasso.bottom() > rowRect.bottom() && lasso.top() < rowRect.top())) {
var bounds = new jSaaspose.Rect(rowRect.left(), rowRect.top() + 1, rowRect.right(), rowRect.bottom() - 1);
bounds.subtract(rows[i].pageLocation);
var r = {
bounds: bounds,
originalRect: rows[i].originalRect,
text: '',
page: pageIndex + (this.options.bookLayout /*|| this.options.useVirtualScrolling */ ? this.options.startNumbers.start - 1 : 0),
row: i,
position: -1,
length: 0
};
rects.push(r);
if (!this.dragged) {
var lastWord = rows[i].words[rows[i].words.length - 1];
r.text = rows[i].text;
r.position = rows[i].words[0].position;
r.length = (lastWord.position + lastWord.text.length - r.position);
}
}
else {
var r = this._getRowHighlightRect(pageIndex, i);
if (r != null) {
rects.push(r);
}
else
if (this.dragged) {
$("#" + this.pagePrefix + (pageIndex + (this.options.bookLayout ? this.options.startNumbers.start : 1)) +
"-highlight-" + (i + 1) + "-" + selectionCounter + ":not(.static)").remove();
}
}
}
return rects;
},
_getRowHighlightRect: function (pageIndex, rowIndex) {
var lasso = this.lasso;
var lassoTop = Math.min(lasso.top(), lasso.bottom()),
lassoBottom = Math.max(lasso.top(), lasso.bottom());
var page = this.pages[pageIndex];
var pageRotation = page.rotation;
if (typeof pageRotation == "undefined")
pageRotation = 0;
var perpendicular = pageRotation % 180 > 0;
var row = page.rows[rowIndex],
rowTop = row.rect.top(),
rowBottom = row.rect.bottom();
var objectsToSelect = (this._textSelectionByCharModeEnabled && row.chars) ? row.chars : row.words;
var selectToEnd = (rowTop < lassoTop && lassoTop < rowBottom && lassoBottom >= rowBottom) && !perpendicular,
selectFromStart = (lassoTop <= rowTop && rowTop < lassoBottom && lassoBottom < rowBottom),
increment = (selectFromStart ? -1 : 1),
i = (selectFromStart ? objectsToSelect.length - 1 : 0);
for (; i < objectsToSelect.length && i >= 0 && !lasso.intersects(objectsToSelect[i].rect) ; i += increment) {
objectsToSelect[i].shown = false;
}
if (i == objectsToSelect.length || i < 0) {
return null;
}
var objectToSelect = objectsToSelect[i];
var right = 0, bottom = 0;
var left = objectToSelect.rect.left(),
top = objectToSelect.rect.top();
var originalLeft = objectToSelect.originalRect.left(),
originalTop = objectToSelect.originalRect.top();
var originalRight = 0, originalBottom = 0;
var result = {
bounds: null,
text: '',
page: pageIndex + (this.options.bookLayout ? this.options.startNumbers.start - 1 : 0),
row: rowIndex,
position: objectToSelect.position,
length: objectToSelect.text.length
};
for (; i < objectsToSelect.length && i >= 0 && (selectFromStart || selectToEnd || lasso.intersects(objectsToSelect[i].rect)) ; i += increment) {
objectToSelect = objectsToSelect[i];
objectToSelect.shown = true;
if (!this.dragged) {
if (!this._textSelectionByCharModeEnabled) {
if (selectFromStart)
result.text = objectToSelect.text + " " + result.text;
else
result.text += objectToSelect.text + " ";
}
else if (this._textSelectionByCharModeEnabled) {
result.text += objectToSelect.text;
if (objectToSelect.isLastWordChar) {
result.text += ' ';
}
}
}
left = Math.min(left, objectToSelect.rect.left());
top = Math.min(top, objectToSelect.rect.top());
right = Math.max(right, objectToSelect.rect.right());
bottom = Math.max(bottom, objectToSelect.rect.bottom());
originalLeft = Math.min(originalLeft, objectToSelect.originalRect.left());
originalTop = Math.min(originalTop, objectToSelect.originalRect.top());
originalRight = Math.max(originalRight, objectToSelect.originalRect.right());
originalBottom = Math.max(originalBottom, objectToSelect.originalRect.bottom());
}
for (; i < objectsToSelect.length && i >= 0; i += increment) {
objectsToSelect[i].shown = false;
}
var bounds = new jSaaspose.Rect(left, top + 1, right, bottom - 1);
bounds.subtract(page.rect.topLeft);
result.bounds = bounds;
var originalBounds = new jSaaspose.Rect(originalLeft, originalTop + 1, originalRight, originalBottom - 1);
result.originalRect = originalBounds;
// result.length = (objectToSelect.position - result.position + objectToSelect.text.length);
result.length = (objectToSelect.position + objectToSelect.text.length);
return result;
},
_findPageAt: function (point) {
if (this.pages != null) {
for (var i = 0; i < this.pages.length; i++) {
if (this.pages[i].rect.contains(point)) {
return this.pages[i];
}
}
}
return null;
},
_findPageNearby: function (point) {
var minHorizontalDifference = 0, minVerticalDifference = 0, pageNumber = null;
var foundVerticalMatch = false, foundHorizontalMatch = false;
for (var i = 0; i < this.pages.length; i++) {
if (this.pages[i].rect.contains(point)) {
return this.pages[i];
}
else if (point.y >= this.pages[i].rect.top() && point.y <= this.pages[i].rect.bottom()) {
var horizontalDifference = Math.abs(point.x - this.pages[i].rect.left());
if (!foundVerticalMatch || horizontalDifference < minHorizontalDifference) {
minHorizontalDifference = horizontalDifference;
foundVerticalMatch = true;
pageNumber = i;
}
}
else if (point.x >= this.pages[i].rect.left() && point.x <= this.pages[i].rect.right()) {
var verticalDifference = Math.abs(point.y - this.pages[i].rect.top());
if (!foundHorizontalMatch || verticalDifference < minVerticalDifference) {
minVerticalDifference = verticalDifference;
foundHorizontalMatch = true;
pageNumber = i;
}
}
}
return this.pages[pageNumber];
},
findPageAtVerticalPosition: function (y) {
for (var i = 0; i < this.pages.length; i++) {
if ((y >= this.pages[i].rect.top() && y <= this.pages[i].rect.bottom())
|| (y >= this.pages[i].rect.bottom() && (i + 1) >= this.pages.length)
|| (y >= this.pages[i].rect.bottom() && y <= this.pages[i + 1].rect.top())) {
return this.pages[i];
}
}
return null;
},
setTextSelectionMode: function (mode) {
this._textSelectionByCharModeEnabled = mode;
},
setMode: function (mode) {
this._mode = mode;
if (mode == this.SelectionModes.SelectText || mode == this.SelectionModes.SelectTextToStrikeout) {
if (this._lassoCssElement == null)
this._lassoCssElement = $('<style type="text/css">.ui-selectable-helper { visibility: hidden; }</style>').appendTo('head');
}
else
if (this._lassoCssElement) {
this._lassoCssElement.remove();
this._lassoCssElement = null;
}
},
getMode: function () {
return this._mode;
},
getRowsFromRect: function (bounds) {
this.initStorage();
var rect = null;
this.lasso = bounds.clone();
this.lasso = new jSaaspose.Rect(Math.round(this.lasso.left()), Math.round(this.lasso.top()) + 0.001,
Math.round(this.lasso.right()), Math.round(this.lasso.bottom()) - 0.001);
var rects = this._getDocumentHighlightRects();
for (var i = 0; i < rects.length; i++) {
rect = rects[i].bounds;
var pageOffsetX = this.pages[rects[i].page].rect.topLeft.x - this.pages[0].rect.topLeft.x;
var pageOffsetY = this.pages[rects[i].page].rect.topLeft.y; // -this.pages[0].rect.topLeft.y;
rect.add(new jSaaspose.Point(pageOffsetX, pageOffsetY));
}
return rects;
}
});
})(jQuery);
if (!window.jGroupdocs)
window.jGroupdocs = {};
window.jGroupdocs.Pdf2JavaScriptWrapper = function (options) {
this.options = $.extend(true, {},
this.options,
options);
this.init();
};
$.extend(window.jGroupdocs.Pdf2JavaScriptWrapper.prototype, {
documentDescription: null,
_portalService: Container.Resolve("PortalService"),
proportion: 1,
options: {
userId: 0,
privateKey: '',
guid: ''
},
init: function () {
this.documentDescription = JSON.parse(this.options.documentDescription);
},
getPageCount: function () {
if (this.documentDescription.pages)
return this.documentDescription.pages.length;
else if (typeof this.documentDescription.pageCount != "undefined")
return this.documentDescription.pageCount;
else
return 0;
},
getPageSize: function () {
var width = this.documentDescription.widthForMaxHeight;
var height = this.documentDescription.maxPageHeight;
if (typeof width === "undefined" || typeof height === "undefined") {
if (this.documentDescription.pages) {
var page = this.documentDescription.pages[0];
width = page.w;
height = page.h;
}
else
width = height = null;
}
return { width: width, height: height };
},
getContentControls: function () {
return this.documentDescription.contentControls;
},
getBookmarks: function () {
return this.documentDescription.bookmarks;
},
getPages: function (prop, pagesLocation, startPage0, endPage0, synchronousWorkOuter, callCompletionCallback) {
if (!this.documentDescription.pages)
return null;
var pages0 = [];
var totalChars = 0;
this.proportion = prop;
var pageCount = this.documentDescription.pages.length;
if (pageCount > 0 && pagesLocation.length < pageCount
&& pagesLocation.length < endPage0 - startPage0 + 1) // document destroyed while initializing
return null;
var stepLength = 100;
var numberOfSteps = Math.ceil(pageCount / stepLength);
var currentImageWidth = prop * this.documentDescription.widthForMaxHeight;
var step0 = 0;
var executeStep = function (pages, step, scale, startPage, endPage, synchronousWork) {
var mustBreak = false;
for (var index = step * stepLength; index < pageCount && index < (step + 1) * stepLength; index++) {
var page = this.documentDescription.pages[index];
var ploc;
if (typeof startPage !== "undefined") {
if (index < startPage)
continue;
if (index > endPage) {
mustBreak = true;
break;
}
ploc = pagesLocation[index - startPage];
}
else
ploc = pagesLocation[index];
var pageId = page.number;
scale = currentImageWidth / page.w;
var pageRotation = page.rotation;
if (typeof pageRotation == "undefined")
pageRotation = 0;
var pageWidth = page.w;
var pageHeight = page.h;
if (pageRotation % 180 != 0) {
scale *= pageWidth / pageHeight;
}
var pageRows = this.getRows(page, pageId, scale, totalChars, ploc);
//if (pageRows.length) {
//    var lastRowWords = pageRows[pageRows.length - 1].words;
//    if (lastRowWords.length) {
//        var lastWord = lastRowWords[lastRowWords.length - 1];
//        totalChars = (lastWord.position + lastWord.text.length);
//    }
//}
var right = ploc.x + pageWidth * scale;
var bottom = ploc.y + pageHeight * scale;
switch (pageRotation) {
case 90:
case 270:
right = ploc.x + pageHeight * scale;;
bottom = ploc.y + pageWidth * scale;
break;
}
pages.push({
pageId: pageId,
rows: pageRows,
rect: new jSaaspose.Rect(ploc.x, ploc.y, right, bottom),
originalWidth: pageWidth,
rotation: page.rotation
});
/*if (index == 0) {
for (var rowNum = 0; rowNum < pageRows.length; rowNum++) {
$("#docViewer1PagesContainer").append($("<div/>")
.css("position", "absolute")
.css("z-index", 1)
.css("left", pageRows[rowNum].rect.left())
.css("top", pageRows[rowNum].rect.top())
.css("width", pageRows[rowNum].rect.width())
.css("height", pageRows[rowNum].rect.height())
.css("background-color", "rgba(255, 0, 0, 0.5)")
);
}*/
/*for (var rowNum = 0; rowNum < pageRows.length; rowNum++) {
var row = pageRows[rowNum];
for (var wordNum = 0; wordNum < row.words.length; wordNum++) {
var word = row.words[wordNum];
$("#docViewer1PagesContainer").append($("<div/>")
.css("position", "absolute")
.css("z-index", 1)
.css("left", word.rect.left())
.css("top", word.rect.top())
.css("width", word.rect.width())
.css("height", word.rect.height())
.css("background-color", "rgba(255, 0, 0, 0.5)")
);
}
}
}*/
}
if (synchronousWork)
return mustBreak;
step++;
if (step < numberOfSteps && !mustBreak) {
window.setTimeout(function() {
executeStep(pages, step, scale, startPage, endPage);
}, 10);
}
else {
if (callCompletionCallback)
this._setTextPositionsCalculationFinished(true);
}
} .bind(this);
if (synchronousWorkOuter || this.options.synchronousWork) {
for (var i = 0; i < numberOfSteps; i++) {
if (executeStep(pages0, i, prop, startPage0, endPage0, true))
break;
}
if (callCompletionCallback)
this._setTextPositionsCalculationFinished(true);
}
else {
window.setTimeout(function () {
executeStep(pages0, step0, prop, startPage0, endPage0);
}, 10);
}
return pages0;
},
getRows: function (page, pageId, scale, totalChars, ploc) {
var pageRotation = page.rotation;
var pageWidth = page.w;
var pageHeight = page.h;
var rows = [];
if (page.rows) {
for (var index = 0; index < page.rows.length; index++) {
var row = page.rows[index];
var rowWords = this.getWords(row, pageId, scale, totalChars, ploc, pageRotation, pageWidth, pageHeight);
var rowChars = this.getChars(row, pageId, scale, totalChars, ploc, pageRotation, pageWidth, pageHeight);
var rotatedCoords = this.getRotatedtextCoordinates(pageRotation, pageWidth, pageHeight,
row.l, row.t, row.w, row.h);
var rowLeft = rotatedCoords.left;
var rowTop = rotatedCoords.top;
var rowWidth = rotatedCoords.width;
var rowHeight = rotatedCoords.height;
var scaledX = rowLeft * scale,
scaledY = rowTop * scale,
left = scaledX + ploc.x,
top = scaledY + ploc.y,
width = rowWidth * scale,
height = rowHeight * scale;
rows.push({
text: row.s,
words: rowWords,
chars: rowChars,
pageLocation: ploc,
originalRect: new jSaaspose.Rect(rowLeft, rowTop, rowLeft + rowWidth, rowTop + rowHeight),
rect: new jSaaspose.Rect(left, top, left + width, top + height)
});
}
}
return rows;
},
getWords: function (row, pageId, scale, totalChars, ploc, pageRotation, pageWidth, pageHeight) {
var children = [];
var words_x = [];
var words_w = [];
var words = row.s.split(' ');
words_x = $.map(
row.c, // {left, width} array
function (val, index) {
if (index % 2 == 0)
return val;
else
words_w.push(val);
}
);
for (var i = 0; i < words_x.length; i++) {
var rotatedCoords = this.getRotatedtextCoordinates(pageRotation, pageWidth, pageHeight,
words_x[i], row.t, words_w[i], row.h);
var wordLeft = rotatedCoords.left;
var wordTop = rotatedCoords.top;
var wordWidth = rotatedCoords.width;
var wordHeight = rotatedCoords.height;
var scaledX = Math.round(wordLeft * scale),
scaledY = Math.round(wordTop * scale),
left = scaledX + ploc.x,
top = scaledY + ploc.y,
width = Math.round(wordWidth * scale),
height = Math.round(wordHeight * scale);
children.push({
text: words[i],
pageLocation: ploc,
originalRect: new jSaaspose.Rect(wordLeft, wordTop, wordLeft + wordWidth, wordTop + wordHeight),
rect: new jSaaspose.Rect(left, top, left + width, top + height)
});
}
return children;
},
getChars: function (row, pageId, scale, totalChars, ploc, pageRotation, pageWidth, pageHeight) {
var children = [];
var chars_x = [];
var chars_w = [];
var isLastWordCharFlags = [];
var wordsLine = row.s.replace(/\s+/g, '');
if (row.ch) {
var spaceCount = 1;
for (var j = 0; j < row.ch.length; j++) {
if (row.s.charAt(j + spaceCount) == ' ') {
spaceCount++;
isLastWordCharFlags.push(true);
}
else if (j != (row.ch.length - 1)) {
isLastWordCharFlags.push(false);
}
chars_x.push(row.ch[j]);
if (j < (row.ch.length - 1)) {
chars_w.push(row.ch[j + 1] - row.ch[j]);
}
else if (j == (row.ch.length - 1)) {
isLastWordCharFlags.push(true);
chars_w.push(row.w - row.ch[j]);
}
}
for (var i = 0; i < chars_x.length; i++) {
var rotatedCoords = this.getRotatedtextCoordinates(pageRotation, pageWidth, pageHeight,
chars_x[i], row.t, chars_w[i], row.h);
var charLeft = rotatedCoords.left;
var charTop = rotatedCoords.top;
var charWidth = rotatedCoords.width;
var charHeight = rotatedCoords.height;
var scaledX = Math.round(charLeft * scale),
scaledY = Math.round(charTop * scale),
left = scaledX + ploc.x,
top = scaledY + ploc.y,
width = Math.round(charWidth * scale),
height = Math.round(charHeight * scale);
children.push({
text: wordsLine.charAt(i),
isLastWordChar: isLastWordCharFlags[i],
pageLocation: ploc,
originalRect: new jSaaspose.Rect(charLeft, charTop, charLeft + charWidth, charTop + charHeight),
rect: new jSaaspose.Rect(left, top, left + width, top + height)
});
}
}
return children;
},
getRowCharacterCoordinates: function (pageNumber, rowNumber) {
var coordinates = this.documentDescription.pages[pageNumber].rows[rowNumber].ch;
return coordinates;
},
reorderPage: function (oldPosition, newPosition) {
var pages = this.documentDescription.pages;
var page = pages[oldPosition];
pages.splice(oldPosition, 1);
pages.splice(newPosition, 0, page);
},
getRotatedtextCoordinates: function (pageRotation, pageWidth, pageHeight,
textLeft, textTop, textWidth, textHeight) {
var resultLeft = textLeft, resultTop = textTop,
resultWidth = textWidth, resultHeight = textHeight;
switch (pageRotation) {
case 90:
resultLeft = pageHeight - textTop - textHeight;
resultTop = textLeft;
resultWidth = textHeight;
resultHeight = textWidth;
break;
case 180:
resultLeft = pageWidth - textLeft - textWidth;
resultTop = pageHeight - textTop - textHeight;
resultWidth = textWidth;
resultHeight = textHeight;
break;
case 270:
resultLeft = textTop;
resultTop = pageWidth - textLeft - textWidth;
resultWidth = textHeight;
resultHeight = textWidth;
break;
}
return { left: resultLeft, top: resultTop, width: resultWidth, height: resultHeight };
},
_setTextPositionsCalculationFinished: function (value) {
var callback = this.options.setTextPositionsCalculationFinishedCallback;
if (callback)
callback.call(this.options.viewerThis, value);
}
});
(function ($, undefined) {
$.widget('ui.navigation', {
_viewModel: null,
_pageCount: 0,
_create: function () {
if (this.options.createHtml) {
this._createHtml();
}
else if (this.options.createEmbeddedHtml) {
this._createEmbeddedHtml();
}
this._viewModel = this.getViewModel();
ko.applyBindings(this._viewModel, this.element.get(0));
},
_createViewModel: function () {
var viewModel = {
pageInd: ko.observable(1),
pageCount: ko.observable(0)
};
viewModel.up = function () {
this.up();
}.bind(this);
viewModel.down = function () {
this.down();
}.bind(this);
viewModel.selectPage = function (pageIndex) {
this.set(pageIndex);
}.bind(this);
viewModel.onKeyPress = function (viewModelObject, e) {
this.onKeyPress(e);
return true;
}.bind(this);
viewModel.setPageIndex = function (index) {
this.setPageIndex(index);
}.bind(this);
viewModel.openFirstPage = function () {
this.set(1);
}.bind(this);
viewModel.openLastPage = function () {
this.set(this._viewModel.pageCount());
}.bind(this);
viewModel.setPagesCount = function (pagesCount) {
this.setPagesCount(pagesCount);
}.bind(this);
return viewModel;
},
getViewModel: function () {
if (!this._viewModel) {
this._viewModel = this._createViewModel();
}
return this._viewModel;
},
up: function () {
var ci = this._viewModel.pageInd();
var pc = this._viewModel.pageCount();
var ni;
if (ci <= 0)
ni = 1;
else {
if (ci > pc)
ni = pc;
else
ni = ci != 1 ? ci - 1 : 1;
}
this._viewModel.pageInd(ni);
$(this.element).trigger('onUpNavigate', ni);
},
down: function () {
var ci = this._viewModel.pageInd();
var pc = this._viewModel.pageCount();
var ni;
if (ci <= 0)
ni = 1;
else {
if (ci > pc)
ni = pc;
else
ni = ci != pc ? (parseInt(ci) + 1) : ci;
}
this._viewModel.pageInd(ni);
$(this.element).trigger('onDownNavigate', ni);
},
set: function (index) {
var oldPageIndex = this._viewModel.pageInd();
var newPageIndex = this.setPageIndex(index);
var direction = 'up';
if (oldPageIndex > newPageIndex)
direction = 'down';
$(this.element).trigger('onSetNavigate', { pageIndex: newPageIndex, direction: direction });
},
setPageIndex: function (index) {
var newPageIndex = Number(index);
var pc = this._viewModel.pageCount();
if (isNaN(newPageIndex))
newPageIndex = 1;
else if (newPageIndex <= 0)
newPageIndex = 1;
else if (newPageIndex > pc)
newPageIndex = pc;
this._viewModel.pageInd(newPageIndex);
return newPageIndex;
},
openFirstPage: function () {
this.selectPage(1);
},
openLastPage: function () {
this.selectPage(this.pageCount());
},
onKeyPress: function (e) {
if (e.keyCode == 13) {
this.set(this._viewModel.pageInd());
}
},
setPagesCount: function (pagesCount) {
this._pageCount = pagesCount;
this._viewModel.pageCount(pagesCount);
},
_createHtml: function () {
var root = this.element;
root.addClass('left');
$('<span class="new_head_tools_btn h_t_i_nav1" data-bind="click: function() { selectPage(1); }, css: {disabled: pageInd() <= 1}" data-tooltip="First Page" data-localize-tooltip="FirstPage"></span>' +
'<span class="new_head_tools_btn h_t_i_nav2" data-bind="click: up, css: {disabled: pageInd() <= 1}" data-tooltip="Previous Page" data-localize-tooltip="PreviousPage"></span>' +
'<input class="new_head_input" type="text" style="width: 17px;" data-bind="value: pageInd, valueUpdate: [\'afterkeydown\'], event: { keyup: onKeyPress }" />' +
'<p class="new_head_of" data-localize="Of">of</p>' +
'<p class="new_head_of" data-bind="text: pageCount()"></p>' +
//'<p class="new_head_of" data-bind="text: \'of \' + pageCount()"></p>' +
'<span class="new_head_tools_btn h_t_i_nav3" data-bind="click: down, css: {disabled: pageInd() >= pageCount()}" data-tooltip="Next Page" data-localize-tooltip="NextPage"></span>' +
'<span class="new_head_tools_btn h_t_i_nav4" data-bind="click: function() { selectPage(this.pageCount()); }, css: {disabled: pageInd() >= pageCount()}" data-tooltip="Last Page" data-localize-tooltip="LastPage"></span>').appendTo(root);
root.trigger("onHtmlCreated");
},
_createEmbeddedHtml: function () {
var root = this.element;
root.addClass('left');
$('<span class="embed_viewer_icons icon1" data-bind="click: function() { selectPage(1); }"></span>' +
'<span class="embed_viewer_icons icon2" data-bind="click: up"></span>' +
'<p>Page</p>' +
'<input type="text" name="textfield" class="page_nmbr" data-bind="value: pageInd, valueUpdate: [\'afterkeydown\'],  event: { keyup: onKeyPress }"/>' +
'<p>of <span data-bind="text: pageCount()" ></span></p>' +
'<span class="embed_viewer_icons icon3" data-bind="click: down"></span>' +
'<span class="embed_viewer_icons icon4" data-bind="click: function() { selectPage(this.pageCount()); }"></span>'
).appendTo(root);
root.trigger("onHtmlCreated");
}
});
})(jQuery);
(function ($, undefined) {
$.widget('ui.thumbnails', {
_viewModel: null,
_pageCount: 0,
_sessionToken: '',
_docGuid: '',
_docVersion: 1,
_pagesWidth: '150',
_heightWidthRatio: 0,
_thumbsSelected: 0,
_thumbnailWidth: 150,
_portalService: Container.Resolve("PortalService"),
options: {
quality: null,
use_pdf: "false",
baseUrl: null,
userId: 0,
userKey: null,
supportPageRotation: false
},
_create: function () {
this.useHtmlThumbnails = this.options.useHtmlThumbnails;
this.useHtmlBasedEngine = this.options.useHtmlBasedEngine;
this.emptyImageUrl = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mNgYAAAAAMAASsJTYQAAAAASUVORK5CYII=";
if (this.options.supportPageReordering) {
var self = this;
ko.bindingHandlers.sortableArray = {
init: function (element, valueAccessor) {
var thumbnails = valueAccessor();
$(element).sortable({
axis: "y",
update: function (event, ui) {
var movedElement = ui.item[0];
//retrieve our actual data item
var dataItem = ko.dataFor(movedElement);
//var item = ui.item.tmplItem().data;
//figure out its new position
var oldPosition = thumbnails.indexOf(dataItem);
var newPosition = ko.utils.arrayIndexOf(ui.item.parent().children(), movedElement);
ui.item.remove();
//remove the item and add it back in the right spot
if (newPosition >= 0) {
thumbnails.remove(dataItem);
thumbnails.splice(newPosition, 0, dataItem);
}
self.rootElement.trigger("onPageReordered", [oldPosition, newPosition]);
}
});
}
};
}
if (this.options.createHtml) {
this._createHtml();
}
if (this.options.thumbnailWidth)
this._thumbnailWidth = this.options.thumbnailWidth;
this._viewModel = this.getViewModel();
ko.applyBindings(this._viewModel, this.element.get(0));
if (this.options.useInnerThumbnails)
ko.applyBindings(this._viewModel, this.toggleThuumbnailsButton[0]);
},
_createViewModel: function () {
var viewModel =
{
thumbnails: ko.observableArray([]),
pageInd: ko.observable(1),
pageCount: ko.observable(0),
busy: ko.observable(true)
};
viewModel._thumbnailHeight = ko.observable(201);
viewModel.useInnerThumbnails = this.options.useInnerThumbnails;
viewModel.openThumbnails = ko.observable(this.options.openThumbnails);
viewModel.element = this.element;
viewModel.rootElement = this.rootElement;
viewModel.thumbnailPanelElement = this.thumbnailPanelElement;
viewModel.emptyImageUrl = this.emptyImageUrl;
if (this.useHtmlThumbnails)
viewModel.scale = ko.observable(0);
viewModel.scrollThumbnailsPanel = function (e) {
this._onScrollLeftPanel(e);
}.bind(this);
viewModel.selectPage = function (pageIndex) {
this.set(pageIndex);
}.bind(this);
viewModel.showThumbnails = function (show) {
var thumbnail;
for (var i = 0; i < this.thumbnails().length; i++) {
thumbnail = this.thumbnails()[i];
thumbnail.visible(show);
}
};
viewModel.hideThumbnails = function () {
this.showThumbnails(false);
};
viewModel.onProcessPages = function (data, pages, getDocumentPageHtmlCallback, viewerViewModel, pointToPixelRatio, docViewerId) {
this.onProcessPages(data, pages, getDocumentPageHtmlCallback, viewerViewModel, pointToPixelRatio, docViewerId);
}.bind(this);
viewModel.setThumbnailsScroll = function (data) {
this.setThumbnailsScroll(data);
}.bind(this);
viewModel.set = function (index) {
this.set(index);
}.bind(this);
viewModel.setPageWithoutEvent = function (index) {
this.setPageWithoutEvent(index);
}.bind(this);
viewModel.getThumbnailsPanelWidth = function () {
var thumbnailsPanelWidth = 0;
if (this.useInnerThumbnails)
thumbnailsPanelWidth = this.element.parent().width();
return thumbnailsPanelWidth;
};
viewModel.toggleThumbnails = function () {
this.openThumbnails(!this.openThumbnails());
this.rootElement.trigger("onResizeThumbnails", this.thumbnailPanelElement.width());
};
return viewModel;
},
getViewModel: function () {
if (!this._viewModel) {
this._viewModel = this._createViewModel();
}
return this._viewModel;
},
onProcessPages: function (data, pages, getDocumentPageHtmlCallback, viewerViewModel, pointToPixelRatio, docViewerId) {
this._sessionToken = data.token;
this._docGuid = data.guid;
this._docVersion = data.version;
this._viewModel.pageCount(data.page_count);
if (!data.lic && this._viewModel.pageCount() > 3)
this._viewModel.pageCount(3);
this._heightWidthRatio = parseFloat(data.page_size.Height / data.page_size.Width);
var width = this._thumbnailWidth;
var variablePageSizeSupport = false, pageDescriptions = null, maxPageHeight, widthForMaxHeight;
var thumbnailWrapperHeight = null;
var baseScale;
if (data.documentDescription && data.documentDescription.pages) {
variablePageSizeSupport = true;
pageDescriptions = data.documentDescription.pages;
maxPageHeight = data.documentDescription.maxPageHeight;
widthForMaxHeight = data.documentDescription.widthForMaxHeight;
thumbnailWrapperHeight = maxPageHeight / widthForMaxHeight * this._thumbnailWidth;
baseScale = (thumbnailWrapperHeight / maxPageHeight) / pointToPixelRatio;
if (this.useHtmlThumbnails) {
this.getDocumentPageHtmlCallback = getDocumentPageHtmlCallback;
this.viewerViewModel = viewerViewModel;
this._viewModel.docViewerId = docViewerId;
var thumbnailContainerWidth = this.element.width();
//this._viewModel.thumbLeftCoord = (thumbnailContainerWidth - width) / 2;
}
}
//this._viewModel.thumbnails.removeAll();
var notObservableThumbnails = [];
var thumbnailDescription, verticalPadding, thumbnailWidth, thumbnailHeight, backgroundColor;
var spinnerHeight = 47;
var pageCount = this._viewModel.pageCount();
var pageWidth, pageHeight, scaleRatio;
var thumbLeftCoord;
for (var i = 0; i < pageCount; i++) {
thumbnailDescription = {
number: i + 1,
busy: ko.observable(true),
visible: ko.observable(false),
url: ko.observable(this.emptyImageUrl)
};
if (variablePageSizeSupport) {
if (i < pageDescriptions.length) {
pageWidth = pageDescriptions[i].w;
pageHeight = pageDescriptions[i].h;
var prop = pageHeight / pageWidth;
var rotation = pageDescriptions[i].rotation;
if (typeof rotation == "undefined")
rotation = 0;
if (rotation % 180 != 0)
prop = 1 / prop;
thumbnailWidth = this._thumbnailWidth;
thumbnailHeight = this._thumbnailWidth * prop;
if (thumbnailHeight > thumbnailWrapperHeight) {
scaleRatio = thumbnailWrapperHeight / thumbnailHeight;
thumbnailHeight = thumbnailWrapperHeight;
thumbnailWidth = this._thumbnailWidth * scaleRatio;
}
}
else {
thumbnailWidth = this._thumbnailWidth;
thumbnailHeight = 215;
}
thumbnailDescription.width = ko.observable(thumbnailWidth);
thumbnailDescription.height = ko.observable(thumbnailHeight);
verticalPadding = 0;
backgroundColor = "";
if (thumbnailHeight < spinnerHeight) {
verticalPadding = ((spinnerHeight - thumbnailHeight) / 2).toString();
backgroundColor = "white";
}
thumbnailDescription.verticalPadding = ko.observable(verticalPadding);
thumbnailDescription.backgroundColor = ko.observable(backgroundColor);
thumbnailDescription.wrapperHeight = thumbnailWrapperHeight;
//thumbnailDescription.scale = ko.observable(baseScale * pageDescriptions[i].h / maxPageHeight);
thumbnailDescription.scale = ko.observable((thumbnailHeight / pageDescriptions[i].h) / pointToPixelRatio);
thumbLeftCoord = (thumbnailContainerWidth - thumbnailWidth) / 2;
thumbnailDescription.thumbLeftCoord = ko.observable(thumbLeftCoord);
if (this.useHtmlThumbnails) {
thumbnailDescription.htmlContent = pages[i].htmlContent;
}
}
notObservableThumbnails.push(thumbnailDescription);
}
this._viewModel.thumbnails(notObservableThumbnails);
var height = parseInt(this._heightWidthRatio * width);
var thumbCss = "";
if (variablePageSizeSupport) {
//thumbCss = "div.thumbnailsContainer ul li img{background-color:white}";
}
else {
thumbCss = ".grpdx .thumbnailsContainer .thumb-page{min-height:" + height.toString() + "px}";
}
this.loadThumbnails();
},
loadThumbnails: function () {
// var countToShow = Math.ceil($('#thumbnails-container').height() / $('#thumb-1').height()); // count of visible thumbs
var countToShow = Math.ceil(this.element.height() / parseInt(this._heightWidthRatio * 150)); // count of visible thumbs
this._countToShowOnThumbDiv = countToShow;
this._thumbsCountToShow = Number(countToShow) + Math.ceil(Number(Number(countToShow) / 2)); // count thumbs for show
this._thumbsSelected = this._thumbsCountToShow; //_thumbsSelected = _thumbsCountToShow on start
this.retrieveImageUrls(this._viewModel.pageCount());
},
retrieveImageUrls: function (imageCount) {
this._portalService.getImageUrlsAsync(this.options.userId, this.options.userKey, this._docGuid,
(this.options._mode == 'webComponent' ? this._thumbnailWidth : this._thumbnailWidth.toString() + "x"), this._sessionToken, 0, imageCount,
this.options.quality, this.options.use_pdf, this._docVersion, null, null, null, null,
this.options.ignoreDocumentAbsence,
this.options.useHtmlBasedEngine, this.options.supportPageRotation,
function (response) {
response = response.data;
var imageUrls;
if (response.imageUrls && typeof response.image_urls == "undefined")
imageUrls = response.imageUrls;
else
imageUrls = response.image_urls; ;
for (var i = 0; i < imageCount; i++) {
this._viewModel.thumbnails()[i].url(imageUrls[i]);
}
this._onScrollLeftPanel();
}.bind(this),
function (error) {
for (var i = 0; i < imageCount; i++) {
this.makeThumbnailNotBusy(i);
}
}.bind(this),
this.options.instanceIdToken,
this.options.locale
);
},
makeThumbnailNotBusy: function (thumbnailIndex) {
var currentThumbnail = this._viewModel.thumbnails()[thumbnailIndex];
currentThumbnail.busy(false);
},
_onScrollLeftPanel: function () {
var pageCount = this._viewModel.pageCount();
var width = this._thumbnailWidth;
var thumbContainer = this.element;
var thumbnailHeight = thumbContainer.find(".thumb-page:first").outerHeight(false); // div height
var scrollTop = thumbContainer.scrollTop();
var th = thumbContainer.height(); // thumbnails height
var startIndex = Math.floor(scrollTop / thumbnailHeight);
var endIndex = Math.floor((scrollTop + th) / thumbnailHeight) + 1;
var end = (endIndex < pageCount - 2) ? endIndex + 2 : pageCount;
for (var i = startIndex; i < end; i++) {
if (this.useHtmlThumbnails) {
this.getDocumentPageHtmlCallback.call(this.viewerViewModel, i);
}
this._viewModel.thumbnails()[i].visible(true);
}
this._thumbsSelected = endIndex;
},
setThumbnailsScroll: function (data) {
var index = data.pi;
if (this._viewModel.pageInd() != index) {
this._viewModel.pageInd(index);
if (!data.eventAlreadyRaised)
this.element.trigger('onSetThumbnailsScroll', index);
}
var thumbnailsContainerTop = this.element.offset().top;
var thumbWrapper = this.element.children("ul").children("li:nth-child(" + this._viewModel.pageInd() + ")");
if (thumbWrapper.length == 0)
return;
var thumbPageTop = thumbWrapper.offset().top;
var divBottomPos = thumbPageTop - $(window).height();
var divTopPos = thumbPageTop + thumbWrapper.height() - thumbnailsContainerTop;
var leftScrollPos = this.element.scrollTop();
var dif = thumbPageTop - thumbnailsContainerTop;
if (divBottomPos > 0 || divTopPos < 0) {
this.element.scrollTop(leftScrollPos + dif);
}
},
set: function (index) {
this._viewModel.pageInd(index);
$(this.element).trigger('onSetThumbnails', index);
},
setPageWithoutEvent: function (index) {
this._viewModel.pageInd(index);
},
setPagesCount: function (pagesCount) {
this._pageCount = pagesCount;
this._viewModel.pageCount(pagesCount);
},
_createHtml: function () {
var root = this.element;
var foreachOperator;
if (this.options.supportPageReordering) {
//foreachOperator = "sortable: {data: thumbnails, afterMove: function(arg){console.log('arg.sourceIndex:',arg.sourceIndex)}}";
foreachOperator = "foreach: thumbnails, sortableArray: thumbnails";
}
else {
foreachOperator = "foreach: thumbnails";
}
this.element = $(
'<div class="thumbnailsContainer" data-bind="event: { scroll: function(e) { scrollThumbnailsPanel(e); } }, visible:!useInnerThumbnails || openThumbnails">' +
'    <ul class="vertical-list2 ui-selectable" data-bind="' + foreachOperator + '">' +
'        <li class="thumb-page ui-selectee" data-bind="style: {height: $data.wrapperHeight + \'px\'}, css: { \'ui-selected\': ($index() + 1) == $root.pageInd() }, click: function() { $root.selectPage($index() + 1); }">' +
//'                <div class="thumbnail_wrapper" data-bind="style: {height: $data.height() + 2 * $data.verticalPadding() + \'px\'}">' +
(this.useHtmlThumbnails ?
(
'        <div class="thumbnail_wrapper" data-bind="style: {width:$data.width() + \'px\',height: $data.height() + 2 * $data.verticalPadding() + \'px\'}">' +
'           <div class="html_page_contents"' +
'                 data-bind="html: htmlContent, ' +
'                        visible: visible(),' +
'                        attr: {id: $root.docViewerId + \'pageHtml-\' + ($index() + 1) },' +
'                        style: { padding: $data.verticalPadding() + \'px 0\', ' +
'                                   MozTransform: \'scale(\' + $data.scale() + \')\', ' +
'                                    \'-webkit-transform\': \'scale(\' + $data.scale() + \')\',' +
'                                    \'-ms-transform\': \'scale(\' + $data.scale() + \')\' }">' +
'            </div>' +
'           <div class="html_page_contents mouse_intercept_overlay">' +
'            </div>'
)
:
(
'                <div class="thumbnail_wrapper" data-bind="style: {height: $data.height() + 2 * $data.verticalPadding() + \'px\'}">' +
'                    <img class="ui-selectee thumb_image" src="' + this.emptyImageUrl + '" data-bind="attr: {src: visible() ? url() : $root.emptyImageUrl}, style: {width: (visible() ? $data.width() : 0) + \'px\', height: (visible() ? $data.height() : 0) + \'px\', padding: $data.verticalPadding() + \'px 0\', backgroundColor: $data.backgroundColor()}" />'
)) +
'                </div>' +
'                <span class="progresspin thumb_progress"></span>' +
'        </li>' +
'    </ul>' +
'</div>');
if (this.options.useInnerThumbnails) {
this.thumbnailPanelElement = $('<div class="thumbnail_panel"></div>');
this.element.appendTo(this.thumbnailPanelElement);
this.toggleThuumbnailsButton = $('<div class="thumbnail_stripe">' +
'   <a class="thumbnail_open" data-bind="click:function(){toggleThumbnails();}"></a>' +
'</div>');
this.toggleThuumbnailsButton.appendTo(this.thumbnailPanelElement);
this.thumbnailPanelElement.prependTo(root);
}
else {
this.element.appendTo(root);
}
this.rootElement = root;
}
});
})(jQuery);
(function ($, undefined) {
fileOpenDialogViewModel = function (fileOpenDialog, fileUploader, fileExplorer) {
this.fileOpenDialog = fileOpenDialog;
this.fileUploader = fileUploader;
this.fileExplorer = fileExplorer;
this._init();
};
$.extend(fileOpenDialogViewModel.prototype, {
_explorerViewModel: null,
_uploaderElements: [],
_init: function () {
this.fileExplorer.bind('onPathChanged', this._onExplorerPathChanged.bind(this));
this.fileExplorer.bind('onNodeSelected', this._onExplorerNodeSelected.bind(this));
this._explorerViewModel = $(this.fileExplorer).explorer("getViewModel");
this.fileUploader.bind('onStart', this._onFileUploaderStart.bind(this));
this.fileUploader.bind('onProgress', this._onFileUploaderProgress.bind(this));
this.fileUploader.bind('onComplete', this._onFileUploaderComplete.bind(this));
},
_onExplorerPathChanged: function (e, path) {
},
_onExplorerNodeSelected: function (e, node) {
if (node.id > 0 && node.type === 'file') {
$(this.fileOpenDialog.fileExplorer).trigger('fileSelected', node);
}
},
_onFileUploaderStart: function (e, id, fileName, fileSize) {
this._explorerViewModel.busy(true);
this._uploaderElements[id] = this._explorerViewModel.createFile(fileName, fileSize);
},
_onFileUploaderProgress: function (e, id, fileName, loaded, total) {
if (total > 0) {
$(this.fileOpenDialog.explorerProgressPercentage).text(Math.round(loaded / total * 100) + ' %');
}
},
_onFileUploaderComplete: function (e, id, metadata) {
var uploaderElements = this._uploaderElements;
var explorerViewModel = this._explorerViewModel;
$(this.fileOpenDialog.explorerProgressPercentage).text('100 %');
explorerViewModel.busy(false);
if (id && metadata) {
uploaderElements[id].id = metadata.id;
uploaderElements[id].guid = metadata.guid;
uploaderElements[id].url = metadata.url;
uploaderElements[id].Name = metadata.name;
uploaderElements[id].docType(metadata.docType);
uploaderElements[id].sizeInKb(Math.round(metadata.size / 1024));
uploaderElements[id].version = metadata.version;
uploaderElements[id].path = explorerViewModel.path() + '/' + metadata.name;
uploaderElements[id].name(metadata.name);
uploaderElements[id].uploading(false);
uploaderElements[id].open();
}
else {
explorerViewModel._removeEntity(uploaderElements[id]);
}
}
});
})(jQuery);
(function ($, undefined) {
$.widget('ui.fileOpenDialog', {
_viewModel: null,
options: {
autoOpen: true,
url: '',
uploadWebFiles: false,
fileTypes: "doc,docx,docm,dot,dotx,dotm,rtf,odt,ott,pdf",
resourcePrefix: ""
},
_create: function () {
var self = this;
var options = self.options;
var root = this.element;
root.addClass(
'modal ' +
'fade ' +
'modal2 ' +
'modal800px');
var innerWrapper = (self.wrapper = $('<div></div>'))
.addClass('modal_inner_wrapper')
.prependTo(root);
this._buildDialogHeader(innerWrapper);
var content = (self.content = $('<div></div>'))
.addClass('modal_content')
.appendTo(innerWrapper);
var inputWrapLeft = (self.inputWrapLeft = $('<div></div>'))
.addClass('modal_input_wrap_left')
.appendTo(content);
var fileExplorer = (self.fileExplorer = $('<div></div>'))
.addClass('file_browser_content')
.appendTo(inputWrapLeft);
this._buildFileUploader(fileExplorer, self);
var filesArea = (self.filesArea = $('<div></div>'))
.attr('data-bind', 'fileDnD: {}')
.css({ position: 'relative' })
.appendTo(fileExplorer);
var explorerProgressWrapper = $('<div></div>')
.css({ position: 'relative' })
.appendTo(filesArea);
var explorerHeader = $('<div></div>')
.addClass('file_browser_sort')
.appendTo(filesArea);
this._buildExplorerHeaders(explorerHeader, 'file_browser_sort_filename', 'Name', 'File Name', 'FileName');
this._buildExplorerHeaders(explorerHeader, 'file_browser_sort_size', 'Size', 'Size', 'Size');
this._buildExplorerHeaders(explorerHeader, 'file_browser_sort_modified', 'ModifiedOn', 'Modified', 'Modified');
this._buildFoldersList(filesArea);
this._buildFilesList(filesArea);
this._buildFooter(innerWrapper);
this.element.trigger("onHtmlCreated");
this._viewModel = this.getViewModel();
},
_init: function () {
},
_buildDialogHeader: function (parent) {
var close = $('<div></div>')
.addClass('popclose')
.attr('data-dismiss', 'modal')
.appendTo(parent);
var header = $('<div></div>')
.addClass('modal_header')
.appendTo(parent);
var headerText = $('<h3></h3>')
.text('Open File')
.attr("data-localize", "OpenFile")
.appendTo(header);
},
_buildFileUploader: function (parent, self) {
var fileUploader = (self.fileUploader = $('<div></div>'))
.addClass('file_browser_toolbar')
.css({
position: 'relative',
display: 'inline-block',
overflow: 'hidden'
})
.appendTo(parent);
var bindingWithStart = $('<!-- ko with: isNotRootFolder -->')
.appendTo(fileUploader);
var openParentFolderButton = $('<a></a>')
.addClass(
'small_button ' +
'file_browser_upload_btn')
.attr("data-localize", "ParentFolder")
.attr('data-bind', 'click: function () { $parent.openParentFolder();}')
.text('Parent folder')
.appendTo(fileUploader);
var bindingWithEnd = $('<!-- /ko -->')
.appendTo(fileUploader);
if (self.options.uploadWebFiles) {
var openFromUrlButton = (self.openFromUrlButton = $('<a></a>'))
.addClass('small_button')
.text('Open From URL')
.appendTo(fileUploader);
}
},
_buildExplorerProgress: function (parent) {
var explorerProgress = $('<div></div>')
.attr('data-bind', 'visible: busy()')
.addClass('explorer-progress')
.appendTo(parent);
var explorerProgressContent = $('<div></div>')
.css({
position: 'relative',
top: '50px',
left: '50%',
width: '96px',
height: '56px'
})
.appendTo(explorerProgress);
var explorerProgressImg = $('<img/>')
.attr('src', this.options.resourcePrefix + '/Images/uploading.gif')
.attr('alt', '')
.css({
width: '16px',
height: '16px'
})
.appendTo(explorerProgressContent);
var br = $('<br/>')
.appendTo(explorerProgressContent);
var explorerProgressPercentage = (self.explorerProgressPercentage = $('<span></span>'))
.attr('id', 'explorer-progress-percentage')
.appendTo(explorerProgressContent);
},
_buildExplorerHeaders: function (parent, /*elementId,*/elementClass, setOrderBy, headerName, localizationKey) {
var element = $('<a></a>')
.attr('href', '#')
.attr('data-bind', 'click: function() { setOrder("' + setOrderBy + '");}')
.addClass(elementClass)
.appendTo(parent);
var text = $('<h4></h4>')
.text(headerName)
.attr('data-localize', localizationKey)
.appendTo(element);
var smallarrow = $('<span></span>')
.addClass('smallarrow')
.attr('data-bind', 'visible: orderBy() === \'' + setOrderBy + '\', css: {up: orderAsc(), down: !orderAsc()}')
.appendTo(element);
},
_buildFoldersList: function (parent) {
var folderList = $('<ul></ul>')
.addClass('file_browser_folder_list')
.attr('data-bind', 'foreach: folders')
.appendTo(parent);
var foldersListItem = $('<li></li>')
.attr('data-bind', 'attr: { id: \'explorer-entity-\' + id }, click: open')
.appendTo(folderList);
var folderBrowserWrapper = $('<div></div>')
.addClass('file_browser_listbox folderlist')
.appendTo(foldersListItem);
var folderIcon = $('<span></span>')
.addClass(
'listicons ' +
'licon_folder')
.appendTo(folderBrowserWrapper);
var folderName = $('<p></p>')
.addClass(
'listname_file_browser ' +
'foldername')
.attr('data-bind', 'text: name()')
.appendTo(folderBrowserWrapper);
},
_buildFilesList: function (parent) {
var filesList = $('<ul></ul>')
.addClass('file_browser_file_list')
.attr('data-bind', 'foreach: files')
.appendTo(parent);
var fileListItem = $('<li></li>')
.attr('data-bind', 'attr: { id: \'explorer-entity-\' + id }, click: open')
.appendTo(filesList);
var filesBrowserWrapper = $('<div></div>')
.addClass('file_browser_listbox filelist')
.appendTo(fileListItem);
var fileIcon = $('<span></span>')
.addClass('listicons')
.attr('data-bind', 'css: { \'licon_unkwn\': (docType() != \'words\' && docType() != \'pdf\' &&  docType() != \'slides\' &&docType() != \'cells\' && docType() != \'image\' && docType() != \'email\' && docType() != \'diagram\' && docType() != \'project\' && docType() != \'taggedimage\'), \'licon_word\': docType() == \'words\', \'licon_pdf\': docType() == \'pdf\', \'licon_ppt\': docType() == \'slides\', \'licon_xls\': docType() == \'cells\', \'licon_bmp\': (docType() == \'image\' || docType() == \'taggedimage\'), \'licon_outlook\': docType() == \'email\', \'licon_visio\': docType() == \'diagram\', \'licon_mpp\': docType() == \'project\' }')
.appendTo(filesBrowserWrapper);
var fileName = $('<p></p>')
.addClass(
'listname_file_browser ' +
'filename' +
'ellipses')
.attr('data-bind', 'text: name(), ellipsis: true')
.appendTo(filesBrowserWrapper);
var fileSize = $('<p></p>')
.addClass(
'listfilesize ' +
'listsmalltext')
.attr('data-bind', 'text: (sizeInKb() + \'Kb\')')
.appendTo(filesBrowserWrapper);
$('<p></p>')
.addClass(
'listfilesize ' +
'listsmalltext')
.attr('data-bind', 'text: modifiedOn()')
.appendTo(filesBrowserWrapper);
},
_buildFooter: function (parent) {
var footer = (self.footer = $('<div></div>'))
.addClass('modal_footer')
.appendTo(parent);
var btnWrapper = $('<div></div>')
.addClass('modal_btn_wrapper')
.appendTo(footer);
},
_createViewModel: function () {
var url = this.options.hostUrl;
var userId = this.options.userId;
var userKey = this.options.userKey;
var fileExplorer = $(this.fileExplorer).explorer({ userId: userId, privateKey: userKey, pageSize: 30, fileTypes: this.options.fileTypes, urlHashEnabled: this.options.urlHashEnabled, instanceIdToken: this.options.instanceIdToken });
var fileUploader = $(this.fileUploader).uploader({ url: url, userId: userId, key: userKey, proxy: 'Uploader.aspx', fld: '', multiple: true, addFileBtn: $(this.uploadButton) });
return new fileOpenDialogViewModel(this, fileUploader, fileExplorer);
},
getViewModel: function () {
if (!this._viewModel) {
this._viewModel = this._createViewModel();
}
return this._viewModel;
},
destroy: function () {
$.Widget.prototype.destroy.call(this);
}
});
})(jQuery);
(function ($, undefined) {
// File explorer view
$.widget('ui.explorer', {
_viewModel: null,
_init: function () {
var self = this;
this._viewModel = this.getViewModel();
this._viewModel.path.subscribe(function (newValue) {
$(this.element).trigger('onPathChanged', [newValue]);
} .bind(this));
$(this._viewModel).bind('onNodeSelected', function (e, node, initialEvent) {
$(this.element).trigger('onNodeSelected', [node, initialEvent]);
} .bind(this));
ko.applyBindings(this._viewModel, this.element.get(0));
},
_createViewModel: function () {
return new explorerViewModel(
this._getViewModelOptions());
},
_getViewModelOptions: function () {
return {
userId: this.options.userId,
userKey: this.options.privateKey,
pageSize: this.options.pageSize,
fileTypes: this.options.fileTypes,
startupPath: this.options.startupPath,
view: this.options.view,
urlHashEnabled: this.options.urlHashEnabled,
instanceIdToken: this.options.instanceIdToken
};
},
getViewModel: function () {
if (!this._viewModel) {
this._viewModel = this._createViewModel();
}
return this._viewModel;
},
setFilter: function (filter) {
this._viewModel.setFilter(filter);
},
setOrder: function (order) {
this._viewModel.setFilter(order);
}
});
// File explorer model
explorerModel = function (options) {
$.extend(this.options, options);
this._init();
};
$.extend(explorerModel.prototype, {
_portalService: Container.Resolve("PortalService"),
_path: '',
_entitiesLoaded: 0,
_entitiesTotal: 0,
_filter: {
name: '',
types: null
},
_order: {
by: ko.observable('Name'),
asc: ko.observable(true)
},
options: {
userId: '',
userKey: '',
pageSize: 30,
extended: false
},
_init: function () {
},
_loadPage: function (index, path, callback, errorCallback) {
this._portalService.loadFileBrowserTreeData(this.options.userId, this.options.userKey, path,
index ? index : 0, this.options.pageSize,
this._order.by(), this._order.asc(),
this._filter.name, this._filter.types, this.options.extended,
function (response) {
if (response.textStatus === 'success') {
this._entitiesLoaded += response.data.nodes.length;
//this is in fact not the total
//but it helps us logically determine whether there are other
//entities to load, see loadMore for more details
this._entitiesTotal = response.data.count;
callback.apply(this, [path, response.data.nodes]);
}
else {
errorCallback.apply(this, []);
}
} .bind(this),
function (error) {
errorCallback.apply(this, [error]);
} .bind(this),
false,
this.options.instanceIdToken
);
},
openFolder: function (path, callback, errorCallback) {
this._path = path || '';
this._entitiesLoaded = 0;
this._entitiesTotal = 0;
this._loadPage(0, this._path, callback, errorCallback);
},
loadMore: function (callback, errorCallback) {
//if the number of loaded entities is larger then the last number
//of loaded entities(_entitiesTotal) then it means all entities have been loaded
//as far as we know
if (this._entitiesLoaded > this._entitiesTotal) {
return false;
}
//otherwise, we may have some more entities to load (there may also not be any)
var page = Math.ceil(this._entitiesLoaded / this.options.pageSize);
this._loadPage(page, this._path, callback, errorCallback);
return true;
},
createFolder: function (path, callback, errorCallback) {
this._portalService.createFolderAsync(this.options.userId, this.options.userKey, path,
function (response) {
if (response.data > 0) {
callback.apply(this, [path, response.data]);
}
else {
errorCallback.apply(this, [path, null, response.data]);
}
} .bind(this),
function (error) {
errorCallback.apply(this, [error, path]);
} .bind(this)
).Subscribe();
},
setFilter: function (filter) {
this._filter.name = filter.name;
this._filter.types = filter.types;
},
setOrder: function (order) {
if (this._order.by() == order) {
var asc = !this._order.asc();
this._order.asc(asc);
} else {
this._order.asc(true);
this._order.by(order);
}
}
});
// File explorer view model
explorerViewModel = function (options) {
this._init(options);
};
$.extend(explorerViewModel.prototype, {
_model: null,
_filtering: false,
_ordering: false,
_userId: null,
_userKey: null,
urlHashEnabled: true,
busy: ko.observable(false),
path: ko.observable(''),
entities: ko.observableArray(),
files: ko.observableArray(),
folders: ko.observableArray(),
changedUrlHash: false,
view: ko.observable('listing'),
_init: function (options) {
this._model = this._createModel(options);
this._userId = options.userId;
this._userKey = options.userKey;
if (typeof(options.urlHashEnabled) != 'undefined') {
this.urlHashEnabled = options.urlHashEnabled;
}
this.busy = ko.observable(false);
this.path = ko.observable('');
this.entities = ko.observableArray();
this.files = ko.observableArray();
this.folders = ko.observableArray();
this.isNotRootFolder = ko.computed({
read: function () {
return !(this.path() === '');
},
owner: this
});
if (!options.skipStartupPathLoad)
this.openFolder(options.startupPath);
},
_createModel: function (options) {
return new explorerModel(options);
},
_addRoot: function () {
var root = this._createEntity('Home', 'folder');
root.path = '';
this.entities.push(root);
return root;
},
_onEntitiesLoaded: function (path, entities) {
var self = this;
if (self._filtering || self._ordering || path != self.path()) {
self.entities.removeAll();
self.files.removeAll();
self.folders.removeAll();
}
var currentId = 1;
$.each(entities, function (i) {
if (!this.extended) {
var e = this;
if (typeof e.id == "undefined") {
e.id = currentId;
currentId++;
}
self._extendEntity(e);
self.entities.push(e);
}
if (this.type == 'file') {
self.files.push(this);
}
else {
self.folders.push(this);
}
});
self._filtering = false;
self._ordering = false;
self.path(path);
if (this.urlHashEnabled) {
this.changedUrlHash = true;
location.hash = self.view() + '#' + path;
this.changedUrlHash = false;
}
self.busy(false);
},
_onNetworkError: function (error) {
this.busy(false);
jerror(error.Reason || error);
},
_extendEntity: function (entity) {
var self = this;
var supportedTypes = (entity.supportedTypes ? $.map(entity.supportedTypes, function (t) { return t.toUpperCase(); }) : []);
$.extend(entity, {
extended: true,
name: ko.observable(entity.name),
uploading: ko.observable(false),
isNewVersion:false,
processingOnServer:false,
sizeInKb: ko.observable(Math.round(entity.size / 1024)),
docType: ko.observable((entity && entity.docType) ? entity.docType.toLowerCase() : ""),
modifiedOn: function () { return (isNaN(entity.modifyTime) || entity.modifyTime < 0 ? '---' : new Date(entity.modifyTime).format('mmm dd, yyyy')); },
percentCompleted: ko.observable(0),
uploadSpeed: ko.observable(0),
remainingTime: ko.observable(0),
supportedTypes: ko.observableArray(supportedTypes),
thumbnail: ko.observable(entity.thumbnail),
selected: ko.observable(false),
isVisible: ko.observable(true),
viewJobId: ko.observable(null),
viewJobPoller: null
});
entity.statusText = ko.computed(function () {
return (this.viewJobId() && this.viewJobId() > 0 ?
'Server-side processing ...' :
'Time remaining: ' + this.remainingTime() + ' secs @ ' + this.uploadSpeed() + ' kb/Sec.');
}, entity);
entity.open = function (e) {
if (entity.type === 'file') {
$(self).trigger('onNodeSelected', [entity, e]);
} else
self.openFolder(entity.path);
};
entity.viewJobId.subscribe(function (newValue) {
if (newValue && newValue > 0) {
entity.processingOnServer = true;
this.viewJobPoller = new jobPoller({
userId: self._userId,
userKey: self._userKey,
jobId: newValue,
completed: function () {
entity.uploading(false);
entity.processingOnServer = false;
entity.viewJobPoller = null;
},
failed: function (error) {
entity.uploading(false);
entity.processingOnServer = false;
entity.viewJobPoller = null;
},
timedout: function () {
entity.uploading(false);
entity.processingOnServer = false;
entity.viewJobPoller = null;
}
});
this.viewJobPoller.start();
}
});
},
_findEntity: function (name, type) {
for (var i = 0; i < this.entities().length; i++) {
var node = this.entities()[i];
if (node.name().toLowerCase() == name.toLowerCase() && node.type == type) {
return node;
}
}
return null;
},
_findEntityAt: function (path, type) {
for (var i = 0; i < this.entities().length; i++) {
var node = this.entities()[i];
if (node.path().toLowerCase() == path.toLowerCase() && node.type == type) {
return node;
}
}
return null;
},
_createEntity: function (name, type, size, path) {
var entity = {
id: 0,
path: (this.path().trim('/') + '/' + (path ? path : name)).trim('/'),
name: name,
type: type,
docType: 'undefined',
time: new Date().getTime(),
modifyTime: new Date().getTime(),
url: undefined,
isKnown: false,
fileCount: 0,
folderCount: 0,
supportedTypes: [],
selected: false,
size: size
};
this._extendEntity(entity);
return entity;
},
_getPathLevel: function (path) {
return (path && path.length > 0 ? path.length - path.replace(/\/+/g, '').length + 1 : 0);
},
getSelectedEntities: function () {
return $.map(this.entities(), function (item) {
if (item.id && item.selected()) return item;
});
},
openFolder: function (path) {
if (this.busy()) {
return;
}
this.busy(true);
this._model.openFolder(path, this._onEntitiesLoaded.bind(this), this._onNetworkError.bind(this));
},
openParentFolder: function () {
var i = this.path().lastIndexOf('/');
var path = this.path().substr(0, i > 0 ? i : 0);
if (path != this.path()) {
this.openFolder(path);
}
},
loadMore: function () {
if (!this.busy()) {
this.busy(
this._model.loadMore(this._onEntitiesLoaded.bind(this), this._onNetworkError.bind(this)));
}
return this.busy();
},
createFile: function (name, size) {
var existingEntity = this._findEntity(name, 'file');
if (existingEntity) {
existingEntity.uploading(true);
existingEntity.isNewVersion = true;
return existingEntity;
}
var self = this;
var entity = this._createEntity(name, 'file', size);
entity.uploading(true);
entity.isNewVersion = false;
this.entities.push(entity);
this.files.unshift(entity);
return entity;
},
entityExists: function (name, type) {
return (this._findEntity(name, type) != null);
},
setFilter: function (filter) {
this._filtering = true;
this._model.setFilter(filter);
this.openFolder(this.path());
},
setOrder: function (order) {
this._ordering = true;
this._model.setOrder(order);
this.openFolder(this.path());
},
orderBy: function () {
return this._model._order.by();
},
orderAsc: function () {
return this._model._order.asc();
},
findEntity: function (name, type) {
return this._findEntity(name, type);
},
isNullOrWhiteSpace: function (str){
return str === null || str == 'undefined' || str.match(/^ *$/) !== null;
}
});
})(jQuery);
var OverrideMode = {
Override: 0,
Rename: 1,
Break: 2,
Skip: 3
};
(function ($, undefined) {
$.widget('ui.uploader', {
_appender: null,
_handler: null,
options: {
multiple: true,
userId: undefined,
key: '',
url: '',
proxy: '',
fld: 'documents',
formats: '',
onComplete: null,
onStart: null,
addFileBtn: null,
skipErrors: false,
delayedStart: false,
isForUserStorage: false,
overrideMode: OverrideMode.Override
},
_initHandler: function () {
if (this._handler == null) {
var action = Container.Resolve('HttpProvider').buildUrl(this.options.url, this.options.proxy, { 'user_id': this.options.userId, 'fld': this.options.fld });
this._handler = $.handlerFactory.get({
multiple: this.options.multiple,
baseServerHost: this.options.url,
isForUserStorage: this.options.isForUserStorage,
folder: this.options.fld,
action: (this.options.key ? Container.Resolve('HttpProvider').signUrl(action, this.options.key) : action),
skipErrors: this.options.skipErrors,
overrideMode: this.options.overrideMode
});
$(this._handler).hitch('onComplete', this._onComplete, this);
$(this._handler).hitch('onProgress', this._onProgress, this);
$(this._handler).hitch('onStart', this._onStart, this);
}
},
_initAppender: function () {
if (this._appender == null) {
var self = this;
this._appender = new FileAppender({ container: this.element,
multiple: !this._handler.sync, _addFileBtn: this.options.addFileBtn,
onAddItemAction: function (item) {
if (self.options.delayedStart) {
$(self.element).trigger('onFileSelected', [$.fileInputUtils.getName(item), item]);
}
else {
self._uploadFile(item);
}
}
});
}
},
_create: function () {
this._initHandler();
this._initAppender();
},
_onCancel: function (e) {
var id = e.data;
this._handler.cancel(id);
},
_onComplete: function (e, id, result) {
//console.log(result);
if (this.options.onComplete) {
this.options.onComplete.apply(this, [id, result]);
}
else {
$(this.element).trigger('onComplete', [id, result]);
}
},
_beforeStart: function (path) {
if (this.options.beforeStart) {
return this.options.beforeStart(path);
}
else {
return true;
}
},
_onStart: function (e, id, fileName, fileSize) {
if (this.options.onStart) {
this.options.onStart.apply(this, [id, fileName, fileSize]);
}
else {
$(this.element).trigger('onStart', [id, fileName, fileSize]);
}
},
_onProgress: function (e, id, fileName, loaded, total, bytesPerMSec, remainTime) {
if (this.options.onProgress) {
this.options.onProgress.apply(this, [id, fileName, loaded, total, bytesPerMSec, remainTime]);
}
else {
$(this.element).trigger('onProgress', [id, fileName, loaded, total, bytesPerMSec, remainTime]);
}
},
_uploadFile: function (input, overrideMode) {
var id = this._handler.add(input, jSaaspose.utils.getSequenceNumber());
var path = this._handler.getPath(id);
if (typeof overrideMode !== "undefined") {
this._handler.overrideMode = overrideMode;
}
if (!this._beforeStart(path)) {
this._handler.cancel(id);
return;
}
//first, add file html item to the page
var item = this._addFileItem(id, path);
if (this.options.formats == '' || this.options.formats.indexOf(item.ext.toLowerCase()) != -1) {
$(this.element).trigger('onAdded', [item, null]);
//then upload
this._handler.upload(id);
}
else {
$(this.element).trigger('onAdded', [null, 'Not allowed format']);
}
return id;
},
upload: function (id, input) {
throw new 'not implemented';
},
uploadFile: function (input, overrideMode) {
return this._uploadFile(input, overrideMode);
},
cancelUploadFile: function (id) {
this._handler.cancel(id);
},
_addFileItem: function (id, path) {
var item = { id: id, name: path, ext: this._getExt(path) };
return item;
},
_getExt: function (path) {
return Container.Resolve('PathProvider').getExt(path).toUpperCase();
},
_setOption: function (key, value) {
$.Widget.prototype._setOption.call(this, key, value);
if (key === 'fld') {
this._handler = null;
this._initHandler();
}
}
});
UploadHandlerBasic = function (options) {
$.extend(this, options);
};
$.extend(UploadHandlerBasic.prototype, {
action: '',
_inputs: {},
sync: true,
skipErrors: false,
getPath: function (id) {
return $.fileInputUtils.getPath(this._inputs[id]);
},
getSize: function (id) {
var input = this._inputs[id];
return $.fileInputUtils.getSize(input);
},
add: function (fileInput, id) {
this._inputs[id] = fileInput;
$(fileInput).detach();
return id;
},
upload: function (id) {
this._upload(id);
},
cancel: function (id) {
this._cancel(id);
},
_parseResponse: function (html) {
try {
var result = eval('(' + html + ')');
} catch (ex) {
throw 'Error in file processing at server side:' + html;
}
return result;
},
_upload: function (id) { },
_cancel: function (id) { }
});
//with iframe we can send only one file at a time
IFrameHandler = function (options) {
UploadHandlerBasic.apply(this, arguments);
};
$.extend(IFrameHandler.prototype, UploadHandlerBasic.prototype, {
_upload: function (id) {
var fileInput = this._inputs[id];
var fileName = Container.Resolve('PathProvider').getName(this.getPath(id));
$(fileInput).attr('name', fileName);
var form = this._createForm(id);
var iframe = this._createIFrame(id);
form.append(fileInput);
var doc = iframe.get(0).document ? iframe.get(0).document : (iframe.get(0).contentDocument ? iframe.get(0).contentDocument : iframe.get(0).contentWindow.document);
doc.body.appendChild(form.get(0));
iframe.hitch('load', function () {
var response = this._getIframeContentJSON(iframe[0]);
$(this).trigger('onComplete', [id, (response.success ? response.parsed : null)]);
delete this._inputs[id];
setTimeout(function () {
iframe.remove();
}, 1);
}, this);
$(this).trigger('onStart', [id, fileName]);
form.submit();
form.remove();
},
_createForm: function (id) {
var form = $('<form method="post" enctype="multipart/form-data" style="display:none"></form>');
form.attr('id', 'form' + id);
form.attr('target', 'iframe' + id);
form.attr('action', this.isForUserStorage ? this._buildUriForIframeAction() : this.action);
return form;
},
_buildUriForIframeAction: function () {
var _action = '';
$.ajax({
url: this.baseServerHost + "\getFileUploadUrl",
data: "path=" + this.folder + "&forIframe=true",
async: false,
success: function (text) {
_action = text;
}
});
return _action;
},
_createIFrame: function (id) {
var iframe = $('<iframe src="javascript:false;" name="iframe' + id + '" style="display:none" />').appendTo('body');
iframe.attr('id', 'iframe' + id);
return iframe;
},
_cancel: function (id) {
$('iframe' + id).remove();
delete this._inputs[id];
},
_getIframeContentJSON: function (iframe) {
try {
if (!iframe.parentNode) {
return;
}
if (iframe.contentDocument &&
iframe.contentDocument.body &&
iframe.contentDocument.body.innerHTML == "false") {
return;
}
var doc = iframe.contentDocument ? iframe.contentDocument : iframe.contentWindow.document;
var content = doc.body.innerHTML.replace(/^<[^>]+>|<[^>]+>$/g, '');
var parsed = this.isForUserStorage ?
this._correctDataFromIframe(this._parseResponse(content)) : this._parseResponse(content);
return { success: true, parsed: parsed };
}
catch (e) {
//jerror(e);
}
return { success: false, parsed: undefined };
},
_correctDataFromIframe: function (response) {
var correctResponce = {};
correctResponce.code = response.status;
correctResponce.error = response.error_message;
correctResponce.id = response.result.upload_Request_Results[0].id;
correctResponce.fileType = response.result.upload_Request_Results[0].file_type;
correctResponce.docType = response.result.upload_Request_Results[0].type.toLowerCase();
correctResponce.guid = response.result.upload_Request_Results[0].guid;
correctResponce.thumbnail = response.result.upload_Request_Results[0].thumbnail;
correctResponce.upload_time = response.result.upload_Request_Results[0].upload_time;
correctResponce.viewJobId = response.result.upload_Request_Results[0].view_job_id;
correctResponce.size = response.result.upload_Request_Results[0].size;
correctResponce.name = response.result.upload_Request_Results[0].adj_name;
correctResponce.version = response.result.upload_Request_Results[0].version;
correctResponce.url = response.result.upload_Request_Results[0].url;
correctResponce.field_count = 0;
correctResponce.supportedTypes = {};
$.ajax({
type: "POST",
url: this.baseServerHost + "\getJsonFileInfo",
data: { fileType: response.result.upload_Request_Results[0].file_type },
async: false,
success: function (result) {
correctResponce.supportedTypes = result;
}
});
return correctResponce;
}
});
AjaxHandler = function (options) {
UploadHandlerBasic.apply(this, arguments);
this.sync = false;
this._xhrs = {};
};
$.extend(AjaxHandler.prototype, UploadHandlerBasic.prototype, {
updateProgress: function (evt) {
if (evt.lengthComputable) {
var percentComplete = evt.loaded / evt.total;
//console.log('percentComplete=' + percentComplete);
}
},
_upload: function (id) {
var file = this._inputs[id];
var self = this;
var fileName = UploadHandlerBasic.prototype.getPath.apply(this, [id]);
var size = UploadHandlerBasic.prototype.getSize.apply(this, [id]);
//xhr object is used as jQuery doesn't allow yet to upload input file via ajax
var xhr = self._xhrs[id] = new XMLHttpRequest();
//xhr.addEventListener("progress", this.updateProgress, false);
var startTime = new Date().getTime();
xhr.upload.onprogress = function (e) {
if (e.lengthComputable) {
var passed = new Date().getTime() - startTime;
var bytesPerMSec = e.loaded / passed;
var remainTime = ((e.total - e.loaded) * passed) / e.loaded;
$(self).trigger('onProgress', [id, fileName, e.loaded, e.total, bytesPerMSec, remainTime]);
}
};
var isForStorage = this.isForUserStorage;
xhr.onreadystatechange = function () {
if (xhr.readyState == 4) {
if (xhr.status == 0 && xhr['canceled']) {
$(self).trigger('onComplete', [id, 'canceled']);
return;
}
if (xhr.status == 0) {
//jerror();
$(self).trigger('onComplete', [id, null]);
return;
}
var passed = new Date().getTime() - startTime;
var bytesPerMSec = size / passed;
$(self).trigger('onProgress', [id, fileName, size, size, bytesPerMSec, 0]);
var parsed = null;
if (xhr.status == 200) {
try {
if (isForStorage) {
parsed = self._correctData(self._parseResponse(xhr.responseText));
} else {
parsed = self._parseResponse(xhr.responseText);
}
if (parsed.code == 'Unauthorized') {
window.location = Container.Resolve("HttpProvider").buildUrl("/", "sign-in", { 'returnUrl': window.location.href });
return;
}
if (!self.skipErrors) {
if (parsed.code == 'Forbidden') {
throw parsed;
}
if (parsed.code == 'QuotaExceeded') {
throw parsed;
}
if (parsed.code == 'StorageLimitExceeded') {
throw parsed;
}
}
}
catch (e) {
jerror(parsed.error);
parsed = null;
}
}
$(self).trigger('onComplete', [id, parsed]);
delete self._inputs[id];
delete self._xhrs[id];
}
};
if (this.overrideMode == OverrideMode.Rename) {
$(this).trigger('onStart', [id, fileName + " (new copy)", size]);
} else {
$(this).trigger('onStart', [id, fileName, size]);
}
if (this.isForUserStorage) {
xhr.open('POST', self._buildUriForUserStorage(fileName), true);
this.overrideMode = OverrideMode.Override;
} else {
xhr.open('POST', self._buildUri(fileName), true);
}
xhr.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
xhr.setRequestHeader('X-File-Name', encodeURIComponent(fileName));
xhr.setRequestHeader('Content-Type', 'application/octet-stream');
xhr.send(file);
},
_correctData: function (response) {
var correctResponce = {};
correctResponce.id = response.result.id;
correctResponce.code = response.result.status;
correctResponce.fileType = response.result.file_type;
correctResponce.docType = response.result.type.toLowerCase(); ;
correctResponce.guid = response.result.guid;
correctResponce.thumbnail = response.result.thumbnail;
correctResponce.upload_time = response.result.upload_time;
correctResponce.viewJobId = response.result.view_job_id;
correctResponce.size = response.result.size;
correctResponce.name = response.result.adj_name;
correctResponce.version = response.result.version;
correctResponce.url = response.result.url;
correctResponce.error = response.result.error_message;
correctResponce.field_count = 0;
correctResponce.supportedTypes = {};
$.ajax({
type: "POST",
url: this.baseServerHost + "\getJsonFileInfo",
data: { fileType: response.result.file_type },
async: false,
success: function (result) {
correctResponce.supportedTypes = result;
}
});
return correctResponce;
},
_buildUri: function (fileName) {
return this.action + '&' + $.param({ fileName: fileName, multiple: true });
},
_buildUriForUserStorage: function (fileName) {
var _action = '';
$.ajax({
url: this.baseServerHost + "\getFileUploadUrl",
data: "path=" + this.folder + "&" + "filename=" + encodeURIComponent(fileName) + "&" + "overrideMode=" + this.overrideMode,
async: false,
success: function (text) {
_action = text;
}
});
return _action;
},
_cancel: function (id) {
if (this._inputs[id]) {
delete this._inputs[id];
}
if (this._xhrs[id]) {
this._xhrs[id]['canceled'] = true;
this._xhrs[id].abort();
delete this._xhrs[id];
}
}
});
/*LinkHandler = function (options) {
UploadHandlerBasic.apply(this, arguments);
};
$.extend(LinkHandler.prototype, UploadHandlerBasic.prototype, {
_portalService: Container.Resolve("PortalService"),
userId: null,
key: '',
getPath: function (id) {
return this._inputs[id];
},
getSize: function (id) {
return 0;
},
add: function (path, id) {
this._inputs[id] = path;
return id;
},
uploadSync: function (id) {
var path = this._inputs[id];
$(this).trigger('onStart', [id, path]);
try {
var fid = this._portalService.uploadLink(this.userId, this.key, path);
this._onCompleted(id, fid, undefined);
return fid;
}
catch (error) {
this._onCompleted(id, undefined, { Reason: error });
return 0;
}
},
_upload: function (id) {
var path = this._inputs[id];
$(this).trigger('onStart', [id, path]);
this._portalService.uploadLinkAsync(this.userId, this.key, path, function (response) { this._onCompleted(id, response, undefined); } .bind(this),
function (error) { this._onCompleted(id, undefined, error); } .bind(this));
},
_onCompleted: function (id, response, error) {
if (error) {
jerror();
}
$(this).trigger('onComplete', [id, response]);
}
});*/
HandleFactory = function () {
};
$.extend(HandleFactory.prototype, {
get: function (options) {
if (options.multiple && this._isXHRSupported()) {
return new AjaxHandler(options);
}
return new IFrameHandler(options);
},
//to determine if xhr is available in current browser
_isXHRSupported: function () {
var input = $('<input type="file" />');
return (
'multiple' in input[0] &&
typeof File != "undefined" &&
typeof (new XMLHttpRequest()).upload != "undefined");
}
});
ItemAppender = function (options) {
$.extend(this, options);
this._init();
this._subscribe();
};
$.extend(ItemAppender.prototype, {
container: null,
template: '',
onAddItemAction: null,
multiple: false,
_addFileBtn: null,
_input: null,
_init: function () {
this._input = $('#input', this.container);
if (this._addFileBtn == null) {
this._addFileBtn = $('#button', this.container);
}
},
_subscribe: function () {
}
});
FileAppender = function (options) {
ItemAppender.apply(this, arguments);
};
$.extend(FileAppender.prototype, ItemAppender.prototype, {
_init: function () {
ItemAppender.prototype._init.apply(this);
//input is setup with opacity=0 that's why it's invisible but anyway it covers the button
//and handles all input events
this._input = this._createInput().prependTo(this._addFileBtn);
},
_createInput: function () {
var input = $('<input type="file" class="file-input"></input>');
if (this.multiple) {
input.attr('multiple', 'multiple');
}
return input;
},
_subscribe: function () {
this._input.hitch('change', this._onChange, this);
},
_onChange: function (e) {
var self = this;
if (this.multiple) {
$.each(e.target.files, function () { self.onAddItemAction(this) });
$(e.target).remove();
}
else {
this.onAddItemAction(e.target);
}
//add input again
this._input = this._createInput().prependTo(this._addFileBtn);
this._subscribe();
}
});
InputTypeFile = function (options) {
$.extend(this, options);
this._init();
this._subscribe();
};
$.extend(InputTypeFile.prototype, {
onFileSelected: null,
//multiple: false,
name: null,
element: null,
_input: null,
_init: function () {
this._input = this._createInput().prependTo(this.element);
},
_createInput: function () {
var input = $('<input type="file" class="file-input"></input>');
//if (this.multiple) {
//    input.attr('multiple', 'multiple');
//}
input.attr('name', this.name);
return input;
},
_subscribe: function () {
this._input.hitch('change', this._onChange, this);
},
_onChange: function (e) {
var self = this;
//if (this.multiple) {
//    $.each(e.target.files, function () { self.onFileSelected(this) });
//    $(e.target).remove();
//}
//else {
this.onFileSelected(e.target);
//}
}
});
IFrame = function (options) {
$.extend(this, options);
this._init();
};
$.extend(IFrame.prototype, {
values: null,
elements: null,
action: null,
onComplete: null,
_init: function () {
var form = this._createForm();
var iframe = this._createIFrame();
$.each(this.values, function () {
var e = $('<input type="hidden" value="' + this.value + '" name="' + this.name + '"></input>');
form.append(e);
});
$.each(this.elements, function () {
form.append(this);
});
var doc = iframe.get(0).document ? iframe.get(0).document : (iframe.get(0).contentDocument ? iframe.get(0).contentDocument : iframe.get(0).contentWindow.document);
doc.body.appendChild(form.get(0));
iframe.hitch('load', function () {
var response = this._getIframeContentJSON(iframe[0]);
if (this.onComplete) this.onComplete(response.parsed);
//delete this._inputs[id];
setTimeout(function () {
iframe.remove();
}, 1);
}, this);
//$(this).trigger('onStart', [id, fileName]);
form.submit();
form.remove();
},
_createForm: function () {
var form = $('<form method="post" enctype="multipart/form-data" style="display:none"></form>');
form.attr('action', _buildUriForIframeAction());
form.attr('target', 'iframe');
return form;
},
_buildUriForIframeAction: function () {
var _action = '';
$.ajax({
url: "getFileUploadUrl",
data: "path=" + this.folder + "&forIframe=true",
async: false,
success: function (text) {
_action = text;
}
});
return _action;
},
_createIFrame: function () {
var iframe = $('<iframe src="javascript:false;" name="iframe" style="display:none" />').appendTo('body');
return iframe;
},
_getIframeContentJSON: function (iframe) {
try {
if (!iframe.parentNode) {
return;
}
if (iframe.contentDocument &&
iframe.contentDocument.body &&
iframe.contentDocument.body.innerHTML == "false") {
return;
}
var doc = iframe.contentDocument ? iframe.contentDocument : iframe.contentWindow.document;
var parsed = this._parseResponse(doc.body.innerHTML);
return { success: true, parsed: parsed };
}
catch (e) {
jerror();
}
return { success: false, parsed: undefined };
},
_parseResponse: function (html) {
try {
var result = eval('(' + html + ')');
} catch (ex) {
throw 'Error in file processing at server side:' + html;
}
return result;
}
});
FileInputUntils = function () { };
$.extend(FileInputUntils.prototype, {
getPath: function (input) {
var s = input.fullPath;
if (s) {
s = s.trimStart('/');
return s.replace(/\//g, '\\');
}
return (input.fileName || input.name || input.value);
},
getName: function (input) {
return Container.Resolve('PathProvider').getName(this.getPath(input));
},
getSize: function (input) {
return input.fileSize != null ? input.fileSize : input.size;
}
});
$.handlerFactory = new HandleFactory();
$.fileInputUtils = new FileInputUntils();
})(jQuery);
(function ($, undefined) {
$.widget('ui.zooming', {
options: {
zoomValues: [5, 15, 25, 50, 75, 100, 125, 150, 175, 200, 300, 400, 600]
},
_viewModel: null,
_create: function () {
if (this.options.createHtml) {
this._createHtml();
}
this._viewModel = this.getViewModel();
ko.applyBindings(this._viewModel, this.element.get(0));
$(this._viewModel).bind('onSetZoom', function (e, value) {
$(this.element).trigger('onSetZoom', [value]);
} .bind(this));
$(this._viewModel).bind("zoomSet.groupdocs", function (e, value) {
this.element.trigger("zoomSet.groupdocs", [value]);
} .bind(this));
},
getViewModel: function () {
if (this._viewModel) {
return this._viewModel;
}
var options = $.extend({ element: this.element }, this.options);
var vm = new zoomingViewModel(options);
return vm;
},
_createHtml: function () {
var root = this.element;
this.element = $(
'<div class="left">' +
'    <a class="new_head_tools_btn h_t_i_zoomin" href="#" data-bind="click: zoomIn" data-tooltip="Zoom In" data-localize-tooltip="ZoomIn"> </a>' +
'    <a class="new_head_tools_btn h_t_i_zoomout" href="#" data-bind="click: zoomOut" data-tooltip="Zoom Out" data-localize-tooltip="ZoomOut"> </a>' +
'    <div class="new_head_tools_dropdown_wrapper">' +
'        <a class="new_head_tools_btn head_tool_dropdown_btn h_t_i_zoom" href="#" data-bind="click: toggleDropDownMenu" data-tooltip="Zoom Level" data-localize-tooltip="ZoomLevel">' +
'        </a>' +
'        <ul class="dropdown-menu head_tool_dropdown" style="display: none;" data-bind="style: {display: (dropDownMenuIsVisible() ? \'block\' : \'none\')}, foreach: zooms">' +
'            <li>' +
'                <a href="#" data-bind="text: name, event: { mousedown: function(item, e) { $parent.setZoom(item, e); } }, attr: {\'data-localize\': $data.localizationKey }"></a>' +
'            </li>' +
'        </ul>' +
'    </div>' +
'</div>'
).appendTo(root);
root.trigger("onHtmlCreated");
}
});
// Zooming Model
zoomingModel = function () {
};
// Zooming ViewModel
zoomingViewModel = function (options) {
$.extend(this, options);
this._init(options);
};
$.extend(zoomingViewModel.prototype, {
_model: null,
zooms: null,
_currentZoom: null,
_currentZoomIndex: 0,
dropDownMenuIsVisible: null,
dropDownMenuClicked: false,
_init: function (options) {
this._currentZoom = ko.observable(100);
this.zooms = ko.observableArray([]);
this.dropDownMenuIsVisible = ko.observable(false);
var zoomValue;
for (var i = options.zoomValues.length - 1; i >= 0; i--) {
zoomValue = options.zoomValues[i];
this.zooms.push({ name: zoomValue.toString() + "%", value: zoomValue });
if (zoomValue == this._currentZoom()) {
this._currentZoomIndex = this.zooms().length - 1;
}
}
this.setFitWidthZoom(100);
this.setFitHeightZoom(100);
},
setFitWidthZoom: function (fitWidthZoom) {
var fitWidthItem = { name: "Fit Width", value: fitWidthZoom, localizationKey: "FitWidth", fitWidth: true };
var found = false;
for (var i = 0; i < this.zooms().length; i++) {
if (this.zooms()[i].fitWidth) {
//this.zooms.splice(i, 1, fitWidthItem);
this.zooms()[i].value = fitWidthZoom;
found = true;
break;
}
}
if (!found)
this.zooms.push(fitWidthItem);
},
setFitHeightZoom: function (fitHeightZoom) {
var fitHeightItem = { name: "Fit Height", value: fitHeightZoom, localizationKey: "FitHeight", fitHeight: true };
var found = false;
for (var i = 0; i < this.zooms().length; i++) {
if (this.zooms()[i].fitHeight) {
//this.zooms.splice(i, 1, fitHeightItem);
this.zooms()[i].value = fitHeightZoom;
found = true;
break;
}
}
if (!found)
this.zooms.push(fitHeightItem);
},
getZoom: function () {
return this._currentZoom();
},
getFitWidthZoomValue: function () {
var zoomItem;
for (var i = 0; i < this.zooms().length; i++) {
zoomItem = this.zooms()[i];
if (zoomItem.fitWidth) {
return zoomItem.value;
}
}
},
getFitHeightZoomValue: function () {
var zoomItem;
for (var i = 0; i < this.zooms().length; i++) {
zoomItem = this.zooms()[i];
if (zoomItem.fitHeight) {
return zoomItem.value;
}
}
},
setZoom: function (item, e) {
var zoom = item.value;
var index = this._indexOfZoom(zoom);
this._currentZoom(zoom);
if (index >= 0) {
this._currentZoomIndex = index;
}
else {
this._currentZoomIndex = this._indexOfNearestZoom(zoom, false);
}
$(this).trigger('onSetZoom', zoom);
$(this).trigger("zoomSet.groupdocs", zoom);
},
setZoomWithoutEvent: function (zoom) {
var index = this._indexOfZoom(zoom);
if (index >= 0) {
this._currentZoom(zoom);
this._currentZoomIndex = index;
}
},
zoomIn: function () {
var changed = false;
var currentZoomIndex = this._currentZoomIndex;
if (this._isFitToBounds()) {
currentZoomIndex = this._indexOfNearestZoom(this.zooms()[this._currentZoomIndex].value, true);
changed = (currentZoomIndex >= 0);
}
else
if (this._currentZoomIndex > 0) {
currentZoomIndex = this._currentZoomIndex - 1;
changed = true;
}
if (changed) {
this._currentZoomIndex = currentZoomIndex;
this._currentZoom(this.zooms()[this._currentZoomIndex].value);
$(this).trigger('onSetZoom', this._currentZoom());
$(this).trigger("zoomSet.groupdocs", this._currentZoom());
}
},
zoomOut: function () {
var changed = false;
var currentZoomIndex = this._currentZoomIndex;
if (this._isFitToBounds()) {
currentZoomIndex = this._indexOfNearestZoom(this.zooms()[this._currentZoomIndex].value, false);
changed = (currentZoomIndex >= 0);
}
else
if (this._currentZoomIndex < this.zooms().length - 1 &&
!(this.zooms()[this._currentZoomIndex + 1].fitWidth || this.zooms()[this._currentZoomIndex + 1].fitHeight)) {
currentZoomIndex = this._currentZoomIndex + 1;
changed = true;
}
if (changed) {
this._currentZoomIndex = currentZoomIndex;
this._currentZoom(this.zooms()[this._currentZoomIndex].value);
$(this).trigger('onSetZoom', this._currentZoom());
$(this).trigger("zoomSet.groupdocs", this._currentZoom());
}
},
_indexOfZoom: function (value) {
for (i = 0; i < this.zooms().length; i++) {
if (this.zooms()[i].value == value) {
return i;
}
}
return -1;
},
_indexOfNearestZoom: function (value, greater) {
var startIndex = this.zooms().length - 1;
var nearestGreaterValue = null, nearestGreaterValueIndex = null,
nearestSmallerValue = null, nearestSmallerValueIndex = null;
var current, currentElement;
for (i = startIndex; i >= 0; i--) {
currentElement = this.zooms()[i];
current = currentElement.value;
if (!currentElement.fitWidth && !currentElement.fitHeight) {
if (current > value && (nearestGreaterValue === null || current < nearestGreaterValue)) {
nearestGreaterValue = current;
nearestGreaterValueIndex = i;
}
else if (current < value && (nearestSmallerValue === null || current > nearestSmallerValue)) {
nearestSmallerValue = current;
nearestSmallerValueIndex = i;
}
}
}
if (greater) {
if (nearestGreaterValueIndex === null)
return -1;
else
return nearestGreaterValueIndex;
}
else {
if (nearestSmallerValueIndex === null)
return -1;
else
return nearestSmallerValueIndex;
}
},
_isFitToBounds: function () {
return (this.zooms()[this._currentZoomIndex].fitWidth || this.zooms()[this._currentZoomIndex].fitHeight);
},
showDropDownMenu: function (show) {
this.dropDownMenuIsVisible(show);
},
toggleDropDownMenu: function (viewModel, event) {
this.dropDownMenuIsVisible(!this.dropDownMenuIsVisible());
this.dropDownMenuClicked = true;
this.element.trigger("onMenuClicked");
event.stopPropagation();
}
//isDropDownMenuClicked: function () {
//    var dropDownMenuClicked = this.dropDownMenuClicked;
//    this.dropDownMenuClicked = false;
//    return dropDownMenuClicked;
//}
});
})(jQuery);
(function ($, undefined) {
$.widget('ui.docViewerPageFlip', {
_viewModel: null,
options: {
fileId: 0,
fileVersion: 1,
userId: 0,
userKey: null,
baseUrl: null,
_mode: 'full',
_docGuid: '',
quality: null,
use_pdf: "true"
},
_create: function () {
$.extend(this.options, {
emptyImageUrl: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mNgYAAAAAMAASsJTYQAAAAASUVORK5CYII="
});
if (this.options.createHtml) {
this._createHtml();
}
this.options.documentSpace = this.element;
this._viewModel = this.getViewModel();
ko.applyBindings(this._viewModel, this.element.get(0));
},
_init: function () {
$(this._viewModel).bind('getPagesCount', function (e, pagesCount) {
$(this.element).trigger('getPagesCount', [pagesCount]);
} .bind(this));
$(this._viewModel).bind('onDocumentLoaded', function (e) {
$(this.element).trigger('onDocumentLoaded');
} .bind(this));
$(this._viewModel).bind('_onProcessPages', function (e, data) {
$(this.element).trigger('_onProcessPages', [data]);
} .bind(this));
$(this._viewModel).bind('onProcessPages', function (e, guid) {
$(this.element).trigger('onProcessPages', [guid]);
} .bind(this));
$(this._viewModel).bind('onScrollDocView', function (e, data) {
$(this.element).trigger('onScrollDocView', [data]);
} .bind(this));
$(this._viewModel).bind('onDocumentLoadComplete', function (e, data) {
$(this.element).trigger('onDocumentLoadComplete', [data]);
} .bind(this));
$(this._viewModel).bind('onSearchPerformed', function (e, searchCountItem) {
$(this.element).trigger('onSearchPerformed', [searchCountItem]);
} .bind(this));
$(this._viewModel).bind('onPageTurned', function (e, pageIndex) {
$(this.element).trigger('onPageTurned', [pageIndex]);
} .bind(this));
},
getViewModel: function () {
if (this._viewModel == null) {
this._viewModel = this._createViewModel();
}
return this._viewModel;
},
_createViewModel: function () {
var vm = new docViewerPageFlipViewModel(this.options);
return vm;
},
applyBindings: function () {
ko.applyBindings(this._viewModel, this.element.get(0));
},
_createHtml: function () {
var viewerHtml =
//'<div id="doc_viewer_page_flip" class="container doc_viewer_flip" data-bind="event: { scroll: function(item, e) { this.ScrollDocView(item, e); }, scrollstop: function(item, e) { this.ScrollDocViewEnd(item, e); } }">' +
'<div id="' + this.options.docViewerId + '_page_flip" class="doc_viewer_flip" data-bind="event: { scroll: function(item, e) { this.ScrollDocView(item, e); }, scrollstop: function(item, e) { this.ScrollDocViewEnd(item, e); } }">' +
'    <a class="page_prev" href="#" style="height: 100%" data-bind="click: previousBroadside"></a>' +
'    <a class="page_next" href="#" style="height: 100%" data-bind="click: nextBroadside"></a>' +
'    <div class="bookCovers" style="display: none">' +
'        <div class="hard hard_ie9 page">' +
'            <a class="page_next2 first_page_link" href="#">' +
'                <h1 class="ellipses" data-bind="text: documentName(), ellipsis: true" style="max-width: 700px;"></h1>' +
'            </a>' +
'        </div>' +
'        <div class="hard hard_ie9 page"></div>' +
'    </div>' +
'    <div style="overflow: hidden;">' +
'        <div class="pages_container_flip page_flip_layout">' +
'            <!-- ko foreach: pages -->' +
'                <div class="doc-page" data-bind="attr: {id: $root.pagePrefix + number}, style: { width: $root.pageWidth() + \'px\', height: $root.pageHeight() + \'px\' }">' +
'                     <div>' +
'                        <div class="button-pane"></div>' +
'                        <div class="highlight-pane"></div>' +
'                        <div class="custom-pane"></div>' +
'                        <div class="search-pane"></div>' +
'                        <img class="page-image page_image_flip" src="' + this.options.emptyImageUrl + '" data-bind="attr: { id: $root.docViewerId +  \'_page_flip-img-\' + number, src: (visible() ? url : $root.emptyImageUrl) }, ' +
'                                                                        style: { width: $root.pageWidth() + \'px\', height: $root.pageHeight() + \'px\' }"/>' +
'                    </div>' +
'                </div>' +
'            <!-- /ko -->' +
'        </div>' +
'    </div>' +
'</div>';
var root = this.element;
this.element = $(viewerHtml).appendTo(root);
root.trigger("onHtmlCreated");
//this.element = $("#" + this.options.docViewerId);
}
});
// Doc Viewer Model
var docViewerPageFlipModel = function (options) {
$.extend(this, options);
this._init();
};
$.extend(docViewerPageFlipModel.prototype, {
_init: function () {
this._portalService = Container.Resolve("PortalService");
},
loadDocument: function (fileId, pagesCountToShow, imageWidth, callback, errorCallback) {
switch (this._mode) {
case 'embed':
this._portalService.viewEmbedDocumentAllAsync(this.userId, this.userKey, fileId, imageWidth, this.quality, this.use_pdf, -1, null,
function (response) {
if (response.data != null && typeof (response.data.guid) !== "undefined") {
callback.apply(this, [response.data]);
}
else {
errorCallback.apply(this, [{}]);
}
},
function (error) {
errorCallback.apply(this, [error]);
});
break;
case 'embedlite':
this._portalService.viewDocumentAllAsync(this.userId, this.userKey, fileId, null, null, null, null, this.quality, this.use_pdf,
function (response) {
if (typeof (response.data.guid) !== "undefined") {
callback.apply(this, [response.data]);
}
else {
errorCallback.apply(this);
}
},
function (error) {
errorCallback.apply(this, [error]);
},
false);
break;
default:
this._portalService.viewDocumentAllAsync(this.userId, this.userKey, fileId, null, pagesCountToShow, imageWidth, null, this.quality, this.use_pdf,
function (response) {
if (response.data && typeof (response.data.guid) !== "undefined") {
callback.apply(this, [response.data]);
}
else {
errorCallback.apply(this);
}
},
function (error) {
errorCallback.apply(this, [error]);
},
false);
break;
}
},
loadProperties: function (fileId, callback) {
this._portalService.getDocInfoAsync(this.userId, this.userKey, fileId,
function (response) {
callback.apply(this, [response.data]);
});
},
retrieveImageUrls: function (fileId, imageCount, pagesDimension, token, callback, errorCallback) {
this._portalService.getImageUrlsAsync(this.userId, this.userKey, fileId, pagesDimension, token, 0, imageCount, this.quality == null ? '' : this.quality, this.use_pdf, this.fileVersion,
function (response) {
callback.apply(this, [response.data]);
},
function (error) {
errorCallback.apply(this, [error]);
});
}
});
// Doc Viewer View Model
window.docViewerPageFlipViewModel = function (options) {
$.extend(this, options);
this._create(options);
};
$.extend(window.docViewerPageFlipViewModel.prototype, {
_model: null,
pagesDimension: null,
pageImageWidth: 568.0,
imageHorizontalMargin: 34,
initialZoom: 100,
zoom: null,
scale: null,
docWasLoadedInViewer: false,
scrollPosition: [0, 0],
inprogress: null,
pages: null,
pageInd: null,
pageWidth: null,
pageHeight: null,
pageCount: null,
docType: null,
fileId: null,
_dvselectable: null,
_thumbnailHeight: 140,
_firstPage: null,
imageUrls: [],
pagePrefix: "page-flip-",
documentName: null,
fit90PercentWidth: false,
_pageBounds: null,
changedUrlHash: false,
bookWidth: 0,
pagingBarWidth: 30,
turnPageWithoutEvent: false,
minimumImageWidth: null,
_create: function (options) {
this._model = new docViewerPageFlipModel(options);
this._init(options);
},
_init: function (options) {
this.pages = ko.observableArray([]);
this.scale = ko.observable(this.initialZoom / 100);
this.zoom = ko.observable(this.initialZoom);
this.inprogress = ko.observable(false),
this.pageLeft = ko.observable(0);
this.pageInd = ko.observable(1);
this.pageWidth = ko.observable(0);
this.pageHeight = ko.observable(0);
this.pageCount = ko.observable(0);
this.docType = ko.observable(-1);
//this.fileId = ko.observable(0);
this.documentName = ko.observable("");
if (!this.docViewerId)
this.docViewerId = this.documentSpace.attr('id');
this.pagePrefix = this.docViewerId + "-page-flip-";
if (options.fit90PercentWidth)
this.pageImageWidth = this.documentSpace.width() * 0.9 - 2 * this.imageHorizontalMargin;
this.pagesDimension = Math.floor(this.pageImageWidth).toString() + "x";
if (this.pages().length == 0)
this.pages.push({ number: 1, visible: ko.observable(false), url: ko.observable(this.emptyImageUrl) });
//if (options.fileId) {
//    this.loadDocument();
//}
},
loadDocument: function (fileId) {
this.inprogress(true);
if (typeof (fileId) !== 'undefined')
this.fileId = fileId;
this.docWasLoadedInViewer = false;
//var pagesCountToShow = Math.ceil($('#thumbnails-container').height() / this._thumbnailHeight);
//if (pagesCountToShow == 0)
//    pagesCountToShow = 1;
var pagesCountToShow = 1;
this._model.loadDocument(this.fileId, pagesCountToShow, this.pageImageWidth,
function (response) {
this._onDocumentLoaded(response);
} .bind(this),
function (error) {
this._onError(error);
} .bind(this));
if (typeof viewModelPathOnlineDoc !== 'undefined')
viewModelPathOnlineDoc.pathOnlineDoc('');
},
retrieveImageUrls: function (imageCount) {
var i;
//for (i = 1; i <= this.pages.length; i++)
//    this.pages[i].visible = false;
var pageDimension, pageWidth;
if (this.shouldMinimumWidthBeUsed(this.pageWidth(), true))
pageWidth = this.minimumImageWidth;
else
pageWidth = this.pageWidth();
pageDimension = Math.floor(pageWidth) + "x";
this._model.retrieveImageUrls(this.fileId, imageCount, (this._mode == 'webComponent' ? Math.floor(pageWidth) : pageDimension), this.token,
function (response) {
var newPageIndex;
for (i = 0; i < imageCount; i++) {
this.pages()[i].url(response.image_urls[i]);
newPageIndex = i + 1;
var pageImageElement = this.setImageElementSize(newPageIndex, this.pageWidth(), this.pageHeight());
pageImageElement.attr("src", this.pages()[newPageIndex - 1].url());
}
this.loadImagesForVisiblePages();
} .bind(this),
function (error) {
this._onError(error);
} .bind(this));
},
_onError: function (error) {
this.inprogress(false);
jerror(error.Reason || "The document couldn't be loaded...");
},
_onDocumentLoaded: function (response, pdf2XmlWrapper) {
$(this).trigger('onDocumentLoaded');
this.fileId = response.guid;
this.docGuid = response.guid;
this.documentName(response.name);
this.docType(response.doc_type);
this.pageCount(response.page_count);
this.token = response.token;
$(this).trigger('getPagesCount', response.page_count);
$(this).trigger('_onProcessPages', response);
var pageSize = null;
if (this.use_pdf != 'false') {
//this._pdf2XmlWrapper = new jSaaspose.Pdf2XmlWrapper({ userId: this.userId, privateKey: this.userKey, fileId: this.fileId, guid: this.docGuid });
this._pdf2XmlWrapper = pdf2XmlWrapper;
pageSize = this._pdf2XmlWrapper.getPageSize();
//this.scale(this.pageImageWidth / pageSize.width);
}
this.pagesContainerElement = this.documentSpace.find("div.pages_container_flip");
this.heightWidthRatio = parseFloat(response.page_size.Height / response.page_size.Width);
//this.pageWidth(this.pageImageWidth);
//this.pageWidth((this.documentSpace.width() - pagingBarWidth * 2) / 2);
var viewerWidth;
if (this.viewerWidth)
viewerWidth = this.viewerWidth;
else
viewerWidth = this.documentSpace.parent().width();
this.pageWidth((viewerWidth - this.pagingBarWidth * 2) / 2);
this.pageHeight(Math.round(this.pageWidth() * this.heightWidthRatio));
//this.pageHeight(Math.round(this.pageImageWidth * this.heightWidthRatio));
//this.pages.removeAll();
if (this._dvselectable) {
var selectable = this._dvselectable.data("ui-dvselectable"); // jQueryUI 1.9+
if (!selectable)
selectable = this._dvselectable.data("dvselectable"); // jQueryUI 1.8
selectable.destroy();
}
if (this.pagesContainerElement.turn("is"))
this.pagesContainerElement.turn("destroy");
this.pagesContainerElement.height(this.pageHeight());
this.inprogress(false);
var pageCount = this.pageCount();
var i;
//for (i = 1; i <= pageCount; i++)
//    this.pages.push({ number: i, visible: ko.observable(false), url: ko.observable(''), urlPending: false });
var pagesNotObservable = [];
for (i = 1; i <= pageCount; i++)
pagesNotObservable.push({ number: i, visible: ko.observable(false), url: ko.observable(this.emptyImageUrl) });
//this.pages.push({ number: i, visible: ko.observable(false), url: ko.observable(''), urlPending: false });
this.pages(pagesNotObservable);
this._firstPage = this.pagesContainerElement.find("#" + this.pagePrefix + "1");
$(this).trigger('onProcessPages', [this.docGuid]);
for (i = 0; i < response.image_urls.length && i < this.pages().length; i++) {
this.pages()[i].url(response.image_urls[i]);
}
if (!this.zoomToFitHeight)
this.loadImagesForVisiblePages();
this.initialWidth = this.pageWidth();
if (pageSize != null)
this.scale(this.initialWidth / pageSize.width);
var hCount = Math.floor(this.pagesContainerElement.width() / this._firstPage.width());
if (hCount == 0)
hCount = 1;
this._dvselectable = this.pagesContainerElement.dvselectable({
txtarea: this.selectionContent,
pdf2XmlWrapper: this._pdf2XmlWrapper,
startNumbers: this.getVisiblePagesNumbers(),
pagesCount: this.pageCount(),
proportion: this.scale(),
disabled: this.use_pdf == "true" ? false : true,
pageHeight: this.getPageHeight(),
horizontalPageCount: hCount,
docSpace: this.documentSpace,
bookLayout: true,
pagePrefix: this.pagePrefix
});
this._dvselectable.dvselectable("setVisiblePagesNumbers", this.getVisiblePagesNumbers());
this.docWasLoadedInViewer = true;
this.documentSpace.find("div.bookCovers > div:first").clone().prependTo(this.pagesContainerElement); //.height(this.pageHeight());
this.documentSpace.find("div.bookCovers > div:last").clone().appendTo(this.pagesContainerElement); //.height(this.pageHeight());
this.setPage(1, true, true);
var self = this;
this.pagesContainerElement.turn({
elevation: 50,
acceleration: true,
gradients: true,
autoCenter: true,
duration: 1000,
//width: this.documentSpace.width() - pagingBarWidth * 2,
width: viewerWidth - this.pagingBarWidth * 2,
height: this.pageHeight()
//height: this.pagesContainerElement.height()
});
//ko.applyBindings(this, this.pagesContainerElement.get(0));
this.pagesContainerElement.bind("turning", function (event, page, view) {
var book = $(this);
var pages = book.turn('pages');
if (page > pages) {
event.preventDefault();
return;
}
page = page - 1; // 1 for cover
self.setImageElementSize(page - 1, self.pageWidth(), self.pageHeight());
self.setPage(page - 1, true);
self.setImageElementSize(page, self.pageWidth(), self.pageHeight());
self.setPage(page, true, true);
self.setImageElementSize(page + 1, self.pageWidth(), self.pageHeight());
self.setPage(page + 1, true); // lazy load in advance
self.setImageElementSize(page + 2, self.pageWidth(), self.pageHeight());
self.setPage(page + 2, true);
});
this.pagesContainerElement.bind("turned", function (event, page, view) {
page = page - 1; // 1 for cover
self.setImageElementSize(page - 1, self.pageWidth(), self.pageHeight());
self.setPage(page - 1, true);
self.setImageElementSize(page, self.pageWidth(), self.pageHeight());
self.setPage(page, true);
self.setImageElementSize(page + 1, self.pageWidth(), self.pageHeight());
self.setPage(page + 1, true); // load in advance
self.setImageElementSize(page + 2, self.pageWidth(), self.pageHeight());
self.setPage(page + 2, true);
if (self._dvselectable) {
var visiblePagesNumbers = self.getVisiblePagesNumbers();
var pagesOnScreen = 2;
if (page == pageCount)
pagesOnScreen = 1;
self._dvselectable.dvselectable("reInitPages", self.scale(), visiblePagesNumbers, self.scrollPosition, self.getPageHeight(), pagesOnScreen);
}
var book = $(this);
book.turn('center');
if (!self.turnPageWithoutEvent && page > 0 && page <= pageCount)
$(this).trigger('onPageTurned', page);
self.turnPageWithoutEvent = false;
});
//this.documentSpace.find(".doc_viewer_flip").width(this.pagesContainerElement.width());
this.documentSpace.width(this.pagesContainerElement.width());
if (this.zoomToFitHeight)
this.setZoom(this.getFitHeightZoom());
$(this).trigger('onDocumentLoadComplete', [response]);
},
setDimension: function (val) {
this.pagesDimension = val + "x";
},
setPageWidth: function (val) {
this.pageImageWidth = val;
},
getFitWidthZoom: function () {
var viewerWidth;
if (this.viewerWidth)
viewerWidth = this.viewerWidth;
else
viewerWidth = this.documentSpace.parent().width();
return viewerWidth / ((this.initialWidth + this.pagingBarWidth) * 2) * 100;
},
getFitHeightZoom: function () {
var viewerHeight;
if (this.viewerHeight)
viewerHeight = this.viewerHeight;
else
viewerHeight = this.documentSpace.parent().height();
return viewerHeight / Math.round(this.initialWidth * this.heightWidthRatio) * 100;
},
getPageHeight: function () {
//return (this.use_pdf == 'false' ? this.pageWidth() * this.heightWidthRatio : this.unscaledPageHeight * this.scale());
//return this.pageWidth() * this.heightWidthRatio;
return this.unscaledPageHeight * this.scale();
},
getSelectable: function () {
return this._dvselectable;
},
_onPropertiesLoaded: function (response) {
$(this).trigger('onDocumentLoaded', { fileId: this.fileId, response: response });
},
getFileId: function () {
return this.fileId;
},
ScrollDocView: function (item, e) {
return;
},
ScrollDocViewEnd: function (item, e) {
return;
},
getVisiblePagesNumbers: function () {
var start;
var end;
var currentPage = this.pageInd();
if (currentPage % 2 == 1) {
start = currentPage;
end = currentPage + 1;
}
else {
start = currentPage - 1;
end = currentPage;
}
var pageCount = this.pageCount();
if (end > pageCount)
end = pageCount;
return { start: start, end: end };
},
loadImagesForVisiblePages: function () {
var numbers = this.getVisiblePagesNumbers();
var start = numbers.start;
var end = numbers.end;
for (var i = start; i <= end; i++) {
this.pages()[i - 1].visible(true);
}
return numbers;
},
setPage: function (index, setInternalPageOnly, raiseEvent) {
//this.isSetCalled = true;
var pageCount = this.pageCount();
var newPageIndex = Number(index);
//if (this.pageInd() == newPageIndex)
//    return;
if (newPageIndex > pageCount)
newPageIndex = pageCount;
if (isNaN(newPageIndex) || newPageIndex < 1)
newPageIndex = 1;
var direction;
if (this.pageInd() < newPageIndex) {
direction = 'up';
}
else {
direction = 'down';
}
this.pages()[newPageIndex - 1].visible(true);
if (this.pagesContainerElement) {
var pageImageElement = this.pagesContainerElement.find("#" + this.pagePrefix + newPageIndex.toString() + " img.page-image");
var imageUrl = this.pages()[newPageIndex - 1].url();
if (pageImageElement.attr("src") != imageUrl)
pageImageElement.attr("src", imageUrl);
if (!setInternalPageOnly && this.documentSpace.is(":visible")) {
this.turnPageWithoutEvent = true;
this.pagesContainerElement.turn("page", newPageIndex + 1);
}
if (raiseEvent) {
this.pageInd(newPageIndex);
$(this).trigger("onScrollDocView", { pi: newPageIndex, direction: direction });
}
}
},
setImageElementSize: function (pageIndex, width, height) {
var pageImageElement = this.pagesContainerElement.find("#" + this.pagePrefix + pageIndex.toString() + " img.page-image");
if (pageImageElement.width() != width)
pageImageElement.width(width);
if (pageImageElement.height() != height)
pageImageElement.height(height);
return pageImageElement;
},
previousBroadside: function () {
var currentPageIncludingCover = this.pagesContainerElement.turn("page");
var currentPageNotIncludingCover = currentPageIncludingCover - 1;
var pageCount = this.pageCount();
var newPage;
if (currentPageNotIncludingCover == 0 || currentPageNotIncludingCover > pageCount)
newPage = currentPageNotIncludingCover - 2;
else
newPage = this.pageInd() - 2;
//var newPage = this.pageInd() - 2;
if (newPage < 1)
newPage = 1;
this.setPage(newPage, true);
this.turnPageWithoutEvent = true;
this.pagesContainerElement.turn('previous');
this.pageInd(newPage);
if (newPage > 0 && newPage <= pageCount)
$(this).trigger('onPageTurned', newPage);
},
nextBroadside: function () {
var currentPageIncludingCover = this.pagesContainerElement.turn("page");
var currentPageNotIncludingCover = currentPageIncludingCover - 1;
var pageCount = this.pageCount();
var newPage;
if (currentPageNotIncludingCover == 0 || currentPageNotIncludingCover > pageCount)
newPage = currentPageNotIncludingCover + 2;
else
newPage = this.pageInd() + 2;
//var newPage = this.pageInd() + 2;
if (newPage > pageCount)
newPage = pageCount;
this.setPage(newPage, true);
this.turnPageWithoutEvent = true;
this.pagesContainerElement.turn('next');
this.pageInd(newPage);
if (newPage > 0 && newPage <= pageCount)
$(this).trigger('onPageTurned', newPage);
},
setZoom: function (value) {
this.zoom(value);
if (this.isPageFlipViewerVisible()) {
this.loadPagesZoomed();
if (this._pdf2XmlWrapper) {
var pageSize = this._pdf2XmlWrapper.getPageSize();
this.scale(this.initialWidth / pageSize.width * value / 100);
//this.scale(this.pageImageWidth / pageSize.width * value / 100);
}
//var pager = this.pagesContainerElement.data("turn");
this.pagesContainerElement.width(this.pageWidth() * 2);
this.pagesContainerElement.height(this.pageHeight());
this.documentSpace.width(this.pageWidth() * 2);
this.pagesContainerElement.turn("size", this.pagesContainerElement.width(), this.pagesContainerElement.height());
var pageImages = this.pagesContainerElement.find("img.page_image_flip");
pageImages.width(this.pageWidth());
pageImages.height(this.pageHeight());
this.resizeViewerElement(this.viewerLeft);
this._dvselectable.dvselectable("changeSelectedRowsStyle", this.scale());
var visiblePagesNumbers = this.getVisiblePagesNumbers();
var hCount = Math.floor(this.pagesContainerElement.width() / this._firstPage.width());
if (hCount == 0)
hCount = 1;
this._dvselectable.dvselectable("reInitPages", this.scale(), visiblePagesNumbers, this.scrollPosition, this.pageWidth() * this.heightWidthRatio, hCount);
}
},
loadPagesZoomed: function () {
var newWidth = (this.initialWidth * this.zoom() / 100) >> 0;
var newHeight = (newWidth * this.heightWidthRatio) >> 0;
this.pagesDimension = newWidth + 'x';
this.pageWidth(newWidth);
this.pageHeight(newHeight);
var pageCount = this.pageCount();
//for (var i = 0; i < pageCount; i++) {
//    this.pages()[i].url('');
//}
this.setPage(this.pageInd());
if (!this.shouldMinimumWidthBeUsed(newWidth, true))
this.retrieveImageUrls(pageCount);
},
performSearch: function (value) {
var searchCountItem = this._dvselectable.dvselectable("performSearch", value, this.zoom() / 100);
$(this).trigger('onSearchPerformed', [searchCountItem]);
},
selectTextInRect: function (rect) {
if (this._dvselectable) {
$(this._dvselectable).dvselectable('highlightPredefinedArea', rect);
}
},
deselectTextInRect: function (rect, deleteStatic) {
if (this._dvselectable) {
$(this._dvselectable).dvselectable('unhighlightPredefinedArea', rect, deleteStatic);
}
},
reInitSelectable: function () {
var visiblePagesNumbers = this.getVisiblePagesNumbers();
if (this._dvselectable != null) {
this._dvselectable.dvselectable("reInitPages", this.scale(), visiblePagesNumbers,
this.scrollPosition, this.getPageHeight());
}
},
onDocumentPageSet: function (newPageIndex) {
this.pageInd(newPageIndex);
if (this.isPageFlipViewerVisible())
this.openCurrentPage();
},
openCurrentPage: function () {
if (this.pagesContainerElement)
this.setPage(this.pageInd());
//this.pagesContainerElement.turn("page", this.pageInd() + 1);
},
isPageFlipViewerVisible: function () {
var isVisible = this.documentSpace.is(":visible");
return isVisible;
},
shouldMinimumWidthBeUsed: function (width, checkOriginalDocumentWidth) {
var originalDocumentWidth = null;
if (this.use_pdf != 'false' && checkOriginalDocumentWidth) {
var pageSize = this._pdf2XmlWrapper.getPageSize();
originalDocumentWidth = pageSize.width;
}
return this.minimumImageWidth != null &&
(width <= this.minimumImageWidth || (originalDocumentWidth !== null && originalDocumentWidth < this.minimumImageWidth));
},
resizeViewerElement: function (viewerLeft) {
var parent = this.documentSpace.parent();
var parentWidth = parent.width();
var viewerMainWrapper = parent.parent();
var viewerMainWrapperWidth = viewerMainWrapper.width();
if (typeof viewerLeft == "undefined")
viewerLeft = 0;
else
this.viewerLeft = viewerLeft;
parent.width(viewerMainWrapperWidth - viewerLeft);
//this.documentSpace.width(parentWidth - viewerLeft);
//parent.css("width", viewerMainWrapperWidth - viewerLeft + "px");
this.reInitSelectable();
this.loadImagesForVisiblePages();
}
});
})(jQuery);
(function ($, undefined) {
$.widget('ui.search', {
_viewModel: null,
options: {
isCaseSensitive: false,
searchForSeparateWords: false
},
_create: function () {
$.extend(this.options, { element: this.element });
if (this.options.createHtml) {
this._createHtml();
}
this._viewModel = this.getViewModel();
ko.applyBindings(this._viewModel, this.element.get(0));
},
_init: function () {
},
getViewModel: function () {
if (this._viewModel == null) {
this._viewModel = this._createViewModel();
}
return this._viewModel;
},
_createViewModel: function () {
var vm = new searchViewModel(this.options);
return vm;
},
applyBindings: function () {
ko.applyBindings(this._viewModel, this.element.get(0));
},
_createHtml: function () {
var elementsHtml =
'<input type="text" placeholder="Search" class="input_search" data-localize-ph="Search" data-bind="visible: visible, attr: {dir: useRtl ? \'rtl\' : \'ltr\'}, value: searchValue, valueUpdate: [\'afterkeydown\', \'propertychange\', \'input\'], event: { keypress: keyPressed, keydown: keyDown }">' +
'<span class="input_search_clear" data-bind="visible: visible, click: function(){$root.clearValue();}, clickBubble: false"></span>' +
'<span class="new_head_tools_btn h_t_i_nav2" data-bind="visible: visible, click: findPreviousFromUI, css:{disabled:!previousEnabled()}" data-tooltip="Search Backward" data-localize-tooltip="SearchBackward"></span>' +
'<span class="new_head_tools_btn h_t_i_nav3" data-bind="visible: visible, click: findNextFromUI, css:{disabled:!nextEnabled()}" data-tooltip="Search Forward" data-localize-tooltip="SearchForward"></span>';
var root = this.element;
$(elementsHtml).appendTo(root);
root.trigger("onHtmlCreated");
}
});
// Model
var searchModel = function (options) {
$.extend(this, options);
this._init();
};
$.extend(searchModel.prototype, {
_init: function () {
}
});
// View Model
var searchViewModel = function (options) {
$.extend(this, options);
this._create(options);
};
$.extend(searchViewModel.prototype, {
searchValue: null,
previousEnabled: null,
nextEnabled: null,
minAreaTopRelativeToBeginning: null,
maxAreaTopRelativeToBeginning: null,
searched: false,
viewerIsScrolled: false,
searchForward: false,
closestArea: null,
newHighlightedAreaFirstWordLeftRelative: 0,
newHighlightedAreaLastWordLeftRelative: 0,
highlightAreas: null,
sible: null,
useHtmlBasedEngine: false,
useCaseSensitiveSearch: false,
useAccentInsensitiveSearch: false,
viewerViewModel: null,
pageNumberAttribute: "data-page-num",
useRtl: false,
searchPageAfterScrollingToIt: null,
hitsOnAllPagesAreFound: false,
_create: function (options) {
this._model = new searchModel(options);
this._init(options);
},
_init: function (options) {
this.searchValue = ko.observable("");
this.previousEnabled = ko.observable(true);
this.nextEnabled = ko.observable(true);
this.visible = ko.observable(this.searchIsVisible);
},
triggerSearchEvent: function (isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact, useAccentInsensitiveSearch) {
var searchValue = this.searchValue();
if (!this.searched)
this.element.trigger("onPerformSearch", [searchValue, isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact, useAccentInsensitiveSearch]);
if (searchValue === "")
this.searched = false;
else
this.searched = true;
return false;
},
findClosestArea: function (searchForward,
isCaseSensitive,
searchForSeparateWords,
treatPhrasesInDoubleQuotesAsExact,
useAccentInsensitiveSearch,
pageNumber) {
var searched = this.searched;
this.triggerSearchEvent(isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact, useAccentInsensitiveSearch);
var isCurrentHighlightAreaFound = false;
var currentlyHighlightedAreaLeft = null, currentlyHighlightedAreaTop = null;
var currentlyHighlightedAreaHeight = null;
var currentSearchHighlightClass = "current_search_highlight";
var highlightGroupName = null;
var currentHitPageNumber, currentPages, currentPagesStart, currentPagesEnd;
var startPage, endPage;
currentPages = this.viewerViewModel.getVisiblePagesNumbers();
currentPagesStart = currentPages.start - 1;
currentPagesEnd = currentPages.end - 1;
if (this.useHtmlBasedEngine) {
if (this.useVirtualScrolling && this.isWaitingForPageOpening && pageNumber === undefined) {
return;
}
this.isWaitingForPageOpening = false;
if (this.highlightAreas == null || !this.hitsOnAllPagesAreFound || !searched) {
this.highlightAreas = this.viewerElement.find(".search_highlight_html");
this.hitsOnAllPagesAreFound = true;
endPage = this.viewerViewModel.pageCount();
for (var pageNum = 0; pageNum < endPage; pageNum++) {
if (!this.viewerViewModel.isPageVisible(pageNum)) {
this.hitsOnAllPagesAreFound = false;
break;
}
}
if (this.hitsOnAllPagesAreFound)
this.sortHighlightedAreas(this.highlightAreas);
}
if (this.useVirtualScrolling && pageNumber !== undefined) {
this.highlightAreas = this.highlightAreas.filter("[data-page-num=" + pageNumber + "]");
}
}
else {
if (this.highlightAreas == null || !searched) {
this.highlightAreas = this.viewerElement.find(".search-pane > .search-highlight");
this.sortHighlightedAreas(this.highlightAreas);
}
}
var allHighlightedAreas = this.highlightAreas;
this.currentHighlightArea = this.highlightAreas.filter("." + currentSearchHighlightClass +
",tspan[class*='" + currentSearchHighlightClass + "']"); // SVG
var closestArea = null;
if (this.currentHighlightArea.length > 0) {
if (this.currentHighlightArea.is("[name*='search_highlight']")) {
highlightGroupName = this.currentHighlightArea.attr("name");
this.currentHighlightArea = allHighlightedAreas.filter("[name='" + highlightGroupName + "']");
this.sortHighlightedAreas(this.currentHighlightArea);
}
isCurrentHighlightAreaFound = true;
currentlyHighlightedAreaLeft = this.currentHighlightArea.offset().left;
currentlyHighlightedAreaTop = this.currentHighlightArea.offset().top;
currentlyHighlightedAreaHeight = this.currentHighlightArea.height();
}
if (!this.pagesContainerElement)
this.pagesContainerElement = this.viewerElement.find(".pages_container");
var pagesContainerTop = this.pagesContainerElement.offset().top;
var pagesContainerLeft = this.pagesContainerElement.offset().left;
var scrollTop;
var visibleScreenTop = this.viewerElement.scrollTop();
var searchStartData = this.getScrollTop(visibleScreenTop);
if (!searchStartData.isCurrentlyHighlightedAreaVisible)
isCurrentHighlightAreaFound = false;
scrollTop = Math.floor(searchStartData.scrollTop);
var minDistance = 0, minHorizontalDistance = null;
var areaTop, areaLeft;
var areaTopRelativeToBeginning = 0, closestAreaTopRelativeToBeginning = 0;
var areaLeftRelativeToBeginning = 0;
this.minAreaTopRelativeToBeginning = null;
this.maxAreaTopRelativeToBeginning = null;
this.minAreaLeftRelativeToBeginning = null;
this.maxAreaLeftRelativeToBeginning = null;
var minLeft, maxLeft;
var horizontalDistance;
var firstArea = true;
var self = this;
if (this.useVirtualScrolling && pageNumber !== undefined) {
this.sortHighlightedAreas(this.highlightAreas);
if (searchForward)
closestArea = this.highlightAreas.first();
else
closestArea = this.highlightAreas.last();
closestAreaTopRelativeToBeginning = closestArea.offset().top - pagesContainerTop;
closestArea = closestArea.get(0);
}
else {
var areaElement;
this.highlightAreas.each(function (index) {
if (isCurrentHighlightAreaFound && (!self.useHtmlBasedEngine || self.hitsOnAllPagesAreFound)) {
if (this === self.currentHighlightArea.get(0)) {
var nextHitIndex;
if (searchForward) {
nextHitIndex = index + 1;
if (highlightGroupName !== null)
{
for (; nextHitIndex < self.highlightAreas.length; nextHitIndex++)
if (highlightGroupName != $(self.highlightAreas.get(nextHitIndex)).attr("name"))
break;
}
}
else {
nextHitIndex = index - 1;
if (highlightGroupName !== null)
{
for (; nextHitIndex >= 0; nextHitIndex--)
if (highlightGroupName != $(self.highlightAreas.get(nextHitIndex)).attr("name"))
break;
}
}
if (nextHitIndex >= self.highlightAreas.length) {
closestArea = self.highlightAreas.slice(index, nextHitIndex);
}
else if (nextHitIndex < 0) {
closestArea = self.highlightAreas.slice(0, index + 1);
}
else
closestArea = self.highlightAreas.get(nextHitIndex);
areaElement = $(closestArea);
areaTop = areaElement.offset().top;
areaTopRelativeToBeginning = Math.floor(areaTop - pagesContainerTop);
areaLeft = areaElement.offset().left;
areaLeftRelativeToBeginning = areaLeft - pagesContainerLeft;
closestAreaTopRelativeToBeginning = areaTopRelativeToBeginning;
var firstSearchHitOffset = $(self.highlightAreas.get(0)).offset();
var lastSearchHitOffset = $(self.highlightAreas.get(self.highlightAreas.length - 1)).offset();
self.minAreaTopRelativeToBeginning = firstSearchHitOffset.top - pagesContainerTop;
self.maxAreaTopRelativeToBeginning = lastSearchHitOffset.top - pagesContainerTop;
self.minAreaLeftRelativeToBeginning = firstSearchHitOffset.left - pagesContainerLeft;
self.maxAreaLeftRelativeToBeginning = lastSearchHitOffset.left - pagesContainerLeft;
return false;
}
else
return true;
}
areaElement = $(this);
if (self.useHtmlBasedEngine && isCurrentHighlightAreaFound && highlightGroupName == areaElement.attr("name"))
return;
areaTop = areaElement.offset().top;
areaTopRelativeToBeginning = Math.floor(areaTop - pagesContainerTop);
areaLeft = areaElement.offset().left;
areaLeftRelativeToBeginning = areaLeft - pagesContainerLeft;
if (self.minAreaTopRelativeToBeginning == null || (areaTopRelativeToBeginning == self.minAreaTopRelativeToBeginning && areaLeftRelativeToBeginning < self.minAreaLeftRelativeToBeginning))
self.minAreaLeftRelativeToBeginning = areaLeftRelativeToBeginning;
if (self.maxAreaTopRelativeToBeginning == null || (areaTopRelativeToBeginning == self.maxAreaTopRelativeToBeginning && areaLeftRelativeToBeginning > self.maxAreaLeftRelativeToBeginning))
self.maxAreaLeftRelativeToBeginning = areaLeftRelativeToBeginning;
if (self.minAreaTopRelativeToBeginning == null || areaTopRelativeToBeginning < self.minAreaTopRelativeToBeginning) {
self.minAreaTopRelativeToBeginning = areaTopRelativeToBeginning;
self.minAreaLeftRelativeToBeginning = areaLeftRelativeToBeginning;
}
if (self.maxAreaTopRelativeToBeginning == null || areaTopRelativeToBeginning > self.maxAreaTopRelativeToBeginning) {
self.maxAreaTopRelativeToBeginning = areaTopRelativeToBeginning;
self.maxAreaLeftRelativeToBeginning = areaLeftRelativeToBeginning;
}
if (isCurrentHighlightAreaFound) {
var distanceToCurrentlyHighlighted = Math.abs(areaTopRelativeToBeginning - scrollTop);
if (distanceToCurrentlyHighlighted < 1) {
horizontalDistance = Math.abs(areaLeft - currentlyHighlightedAreaLeft);
if ((horizontalDistance >= 1) &&
((searchForward && areaLeft > currentlyHighlightedAreaLeft) ||
(!searchForward && areaLeft < currentlyHighlightedAreaLeft)) &&
(horizontalDistance < minHorizontalDistance || minHorizontalDistance === null)) {
closestArea = areaElement;
minHorizontalDistance = horizontalDistance;
closestAreaTopRelativeToBeginning = areaTopRelativeToBeginning;
firstArea = false;
}
}
}
if (minHorizontalDistance === null &&
((searchForward && areaTopRelativeToBeginning > scrollTop) ||
(!searchForward && areaTopRelativeToBeginning < scrollTop))) {
var distance = Math.abs(areaTopRelativeToBeginning - scrollTop);
if (distance >= 1) {
if ((distance < minDistance && minDistance - distance >= 1) || firstArea) {
closestArea = areaElement;
minDistance = distance;
closestAreaTopRelativeToBeginning = areaTopRelativeToBeginning;
firstArea = false;
if (searchForward)
minLeft = areaLeft;
else
maxLeft = areaLeft;
}
else if (Math.abs(distance - minDistance) < 1) {
if (searchForward && areaLeft < minLeft) {
minLeft = areaLeft;
closestArea = areaElement;
closestAreaTopRelativeToBeginning = areaTopRelativeToBeginning;
}
if (!searchForward && areaLeft > maxLeft) {
maxLeft = areaLeft;
closestArea = areaElement;
closestAreaTopRelativeToBeginning = areaTopRelativeToBeginning;
}
}
}
}
});
}
var increment, notLoadedPageNum;
if (this.useHtmlBasedEngine && this.useVirtualScrolling && !closestArea && pageNumber === undefined) { // not started search after scrolling to a page already
var viewerPages = this.viewerViewModel.pages();
var pageAreas;
if (searchForward) {
startPage = this.viewerViewModel.lastVisiblePageForVirtualMode() + 1;
increment = 1;
}
else {
startPage = this.viewerViewModel.firstVisiblePageForVirtualMode() - 1;
increment = -1;
}
for (var i = startPage; (searchForward && i < viewerPages.length) || (!searchForward && i >= 0) ; i += increment) {
var page = viewerPages[i];
if (page.parsedHtmlElement) {
pageAreas = page.parsedHtmlElement.find(".search_highlight_html");
if (pageAreas.length > 0) {
this.searchPageAfterScrollingToIt = {
searchForward: searchForward,
pageNumber: i
};
this.viewerViewModel.setPage(i + 1);
return;
}
}
}
}
var newHighlightedAreaFirstWordLeft = null;
var newHighlightedAreaLastWordLeft = null;
if (closestArea) { // found a search hit
var closestAreaJquery = $(closestArea);
var newHitPageNumber = parseInt(closestAreaJquery.attr(this.pageNumberAttribute));
endPage = newHitPageNumber;
if (newHitPageNumber > currentPagesEnd) {
startPage = currentPagesEnd;
increment = 1;
}
else {
startPage = currentPagesStart;
increment = -1;
}
var scrollNow = true;
if (this.useHtmlBasedEngine && newHitPageNumber !== null && !(newHitPageNumber >= currentPagesStart && newHitPageNumber <= currentPagesEnd)) {
for (notLoadedPageNum = startPage; notLoadedPageNum != endPage; notLoadedPageNum += increment) {
if (!this.viewerViewModel.isPageVisible(notLoadedPageNum)) {
// found a search hit outside visible pages
this.loadPagesOnOneLevel(notLoadedPageNum, searchForward, isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact);
scrollNow = false;
break;
}
}
}
if (scrollNow) {
if (closestAreaJquery.is("[name*='search_highlight']")) {
highlightGroupName = closestAreaJquery.attr("name");
closestArea = allHighlightedAreas.filter("[name='" + highlightGroupName + "']");
}
else {
closestArea = closestAreaJquery;
}
this.sortHighlightedAreas(closestArea);
var indexInHighlightGroup = searchForward ? closestArea.length - 1 : 0;
var newHighlightedAreaTop = $(closestArea[indexInHighlightGroup]).offset().top;
var newHighlightedAreaTopRelative = newHighlightedAreaTop - pagesContainerTop;
newHighlightedAreaFirstWordLeft = $(closestArea[0]).offset().left;
this.newHighlightedAreaFirstWordLeftRelative = newHighlightedAreaFirstWordLeft - pagesContainerLeft;
newHighlightedAreaLastWordLeft = $(closestArea[closestArea.length - 1]).offset().left;
this.newHighlightedAreaLastWordLeftRelative = newHighlightedAreaLastWordLeft - pagesContainerLeft;
scrollTop = newHighlightedAreaTopRelative;
closestAreaTopRelativeToBeginning = $(closestArea[0]).offset().top - pagesContainerTop;
this.viewerElement[0].scrollTop = closestAreaTopRelativeToBeginning;
this.viewerIsScrolled = true;
this.viewerElement.trigger("ScrollDocView", [null, { target: this.viewerElement[0] }]);
this.viewerElement.trigger("ScrollDocViewEnd", [null, { target: this.viewerElement[0] }]);
this.viewerIsScrolled = false;
pagesContainerTop = this.pagesContainerElement.offset().top;
var oldClass, newClass;
if (this.currentHighlightArea.is("tspan")) { // SVG
oldClass = this.currentHighlightArea.attr("class");
newClass = oldClass.replace(new RegExp("\\b" + currentSearchHighlightClass + "\\b"), "");
this.currentHighlightArea.attr("class", newClass);
}
else {
this.currentHighlightArea.removeClass(currentSearchHighlightClass);
}
if (closestArea.is("tspan")) { // SVG
oldClass = closestArea.attr("class");
closestArea.attr("class", oldClass + " " + currentSearchHighlightClass);
}
else {
closestArea.addClass(currentSearchHighlightClass);
}
}
}
else {
if (searchForward) {
increment = 1;
startPage = currentPagesEnd;
endPage = this.viewerViewModel.pageCount();
}
else {
increment = -1;
startPage = currentPagesStart;
endPage = -1;
}
if (this.useHtmlBasedEngine && !(newHitPageNumber >= currentPagesStart && newHitPageNumber <= currentPagesEnd)) {
for (notLoadedPageNum = startPage; notLoadedPageNum != endPage; notLoadedPageNum += increment) {
if (!this.viewerViewModel.isPageVisible(notLoadedPageNum)) {
this.loadPagesOnOneLevel(notLoadedPageNum, searchForward, isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact);
break;
}
}
}
}
this.searchForward = searchForward;
if (!closestArea && isCurrentHighlightAreaFound)
closestArea = this.currentHighlightArea;
this.closestArea = closestArea;
var previousEnabled = this.isPreviousEnabled(scrollTop);
this.previousEnabled(previousEnabled);
var nextEnabled = this.isNextEnabled(scrollTop);
this.nextEnabled(nextEnabled);
},
isPreviousEnabled: function (scrollTop) {
// HTML engine
if (this.useHtmlBasedEngine && !this.hitsOnAllPagesAreFound)
return true;
var scrollTopWithHighlighted = this.getScrollTop(scrollTop).scrollTop;
var areaCheck = ((this.minAreaTopRelativeToBeginning != null)
&& (Math.floor(scrollTopWithHighlighted) > Math.ceil(this.minAreaTopRelativeToBeginning)
|| (Math.abs(scrollTopWithHighlighted - this.minAreaTopRelativeToBeginning) < 1 && this.newHighlightedAreaFirstWordLeftRelative !== null && this.newHighlightedAreaFirstWordLeftRelative > this.minAreaLeftRelativeToBeginning)));
return !this.searched || areaCheck;
},
isNextEnabled: function (scrollTop) {
// HTML engine
if (this.useHtmlBasedEngine && !this.hitsOnAllPagesAreFound)
return true;
var scrollTopWithHighlighted = this.getScrollTop(scrollTop).scrollTop;
var areaCheck = ((this.maxAreaTopRelativeToBeginning != null)
&& (Math.ceil(scrollTopWithHighlighted) < Math.floor(this.maxAreaTopRelativeToBeginning)
|| (Math.abs(scrollTopWithHighlighted - this.maxAreaTopRelativeToBeginning) < 1 && this.newHighlightedAreaLastWordLeftRelative !== null && this.newHighlightedAreaLastWordLeftRelative < this.maxAreaLeftRelativeToBeginning)));
return !this.searched || areaCheck;
},
findPreviousFromUI: function () {
this.findPrevious(this.isCaseSensitive, this.searchForSeparateWords, this.treatPhrasesInDoubleQuotesAsExactPhrases, this.useAccentInsensitiveSearch);
},
findNextFromUI: function () {
this.findNext(this.isCaseSensitive, this.searchForSeparateWords, this.treatPhrasesInDoubleQuotesAsExactPhrases, this.useAccentInsensitiveSearch);
},
findPrevious: function (isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExactPhrases, useAccentInsensitiveSearch) {
if (this.searchValue() != "")
this.findClosestArea(false, isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExactPhrases, useAccentInsensitiveSearch);
},
findNext: function (isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExactPhrases, useAccentInsensitiveSearch) {
if (this.searchValue() != "")
this.findClosestArea(true, isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExactPhrases, useAccentInsensitiveSearch);
},
clearValue: function () {
this.searchValue("");
this.resetButtons();
this.triggerSearchEvent();
},
resetButtons: function () {
this.previousEnabled(true);
this.nextEnabled(true);
this.searched = false;
this.highlightAreas = null;
},
keyDown: function (viewModel, event) {
if (event.keyCode == 8 || event.keyCode == 46) { // Backspace, Delete
viewModel.keyHandler(event.keyCode);
}
return true;
},
keyPressed: function (viewModel, event) {
var keyCode = (event.which ? event.which : event.keyCode);
return viewModel.keyHandler(keyCode);
},
keyHandler: function (keyCode) {
if (keyCode === 13) { // Enter
this.findNextFromUI();
return false;
}
this.previousEnabled(true);
this.nextEnabled(true);
this.searched = false;
return true;
},
scrollPositionChanged: function (scrollTop) {
if (this.searched && !this.viewerIsScrolled) {
this.previousEnabled(this.isPreviousEnabled(scrollTop));
this.nextEnabled(this.isNextEnabled(scrollTop));
}
},
showControls: function () {
this.visible(this.searchIsVisible);
},
hideControls: function () {
this.visible(false);
},
documentLoaded: function () {
this.resetButtons();
if (this.searched)
this.element.trigger("onPerformSearch", "");
},
loadPagesOnOneLevel: function (notLoadedPageNum, searchForward, isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact) {
var self = this;
var pagesToLoad = [];
var pageLocations = this.viewerViewModel.getPageLocations();
var pageWidth = this.viewerViewModel.pageWidth();
var viewerViewModelPages = this.viewerViewModel.pages();
var pageBottom = pageLocations[notLoadedPageNum].y + pageWidth * viewerViewModelPages[notLoadedPageNum].prop;
var i;
for (i = notLoadedPageNum + 1; i < pageLocations.length; i++) {
if (Math.abs(pageLocations[i].y + pageWidth * viewerViewModelPages[i].prop - pageBottom) < 2)
pagesToLoad.push(i);
else
break;
}
for (i = notLoadedPageNum - 1; i >= 0; i--) {
if (Math.abs(pageLocations[i].y + pageWidth * viewerViewModelPages[i].prop - pageBottom) < 2)
pagesToLoad.push(i);
else
break;
}
function loadPages() {
if (pagesToLoad.length == 0)
self.findClosestArea(searchForward, isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact);
else
self.viewerViewModel.getDocumentPageHtml(pagesToLoad.pop(), loadPages);
}
this.viewerViewModel.getDocumentPageHtml(notLoadedPageNum, loadPages);
},
getScrollTop: function (scrollTop) {
var isCurrentHighlightAreaFound = (this.closestArea != null);
var currentlyHighlightedAreaTop, currentlyHighlightedAreaBottom;
var currentlyHighlightedAreaHeight;
if (!this.pagesContainerElement)
this.pagesContainerElement = this.viewerElement.find(".pages_container");
var pagesContainerTop = this.pagesContainerElement.offset().top;
var viewerElementHeight = this.viewerElement.height();
var visibleScreenTop = scrollTop;
var visibleScreenBottom = scrollTop + viewerElementHeight;
var currentlyHighlightedAreaTopRelative;
var isCurrentlyHighlightedAreaVisible = false;
if (isCurrentHighlightAreaFound) {
currentlyHighlightedAreaTop = null;
currentlyHighlightedAreaBottom = null;
this.closestArea.each(function () {
var jqueryAreaFromGroup = $(this);
var currentAreaTop = jqueryAreaFromGroup.offset().top;
if (currentlyHighlightedAreaTop === null || currentAreaTop < currentlyHighlightedAreaTop)
currentlyHighlightedAreaTop = currentAreaTop;
var dimensions = this.getBoundingClientRect();
var screenHeight;
if (typeof dimensions.height == "undefined") // IE8
screenHeight = dimensions.bottom - dimensions.top;
else
screenHeight = dimensions.height;
var currentAreaBottom = currentAreaTop + screenHeight;
if (currentlyHighlightedAreaBottom === null || currentAreaBottom > currentlyHighlightedAreaBottom)
currentlyHighlightedAreaBottom = currentAreaBottom;
});
currentlyHighlightedAreaHeight = currentlyHighlightedAreaBottom - currentlyHighlightedAreaTop;
currentlyHighlightedAreaTopRelative = currentlyHighlightedAreaTop - pagesContainerTop;
if (Math.ceil(currentlyHighlightedAreaTopRelative) + currentlyHighlightedAreaHeight >= visibleScreenTop &&
Math.floor(currentlyHighlightedAreaTopRelative) <= visibleScreenBottom) {
scrollTop = currentlyHighlightedAreaTopRelative;
isCurrentlyHighlightedAreaVisible = true;
}
}
return { scrollTop: scrollTop, isCurrentlyHighlightedAreaVisible: isCurrentlyHighlightedAreaVisible };
},
documentPageSetHandler: function () {
if (this.useVirtualScrolling && this.searchPageAfterScrollingToIt) {
var self = this;
var searchForward = this.searchPageAfterScrollingToIt.searchForward;
var pageNumber = this.searchPageAfterScrollingToIt.pageNumber;
this.searchPageAfterScrollingToIt = null;
this.isWaitingForPageOpening = true;
window.setTimeout(function () {
self.findClosestArea(searchForward,
self.isCaseSensitive,
self.searchForSeparateWords,
self.treatPhrasesInDoubleQuotesAsExactPhrases,
self.useAccentInsensitiveSearch,
pageNumber);
}, 1000);
}
else {
if (!this.pagesContainerElement)
this.pagesContainerElement = this.viewerElement.find(".pages_container");
var visibleScreenTop = this.viewerElement.scrollTop();
this.scrollPositionChanged(visibleScreenTop);
}
},
sortHighlightedAreas: function (areas) {
areas.sort(function (areaElement1, areaElement2) {
var jqueryAreaElement2 = $(areaElement2), jqueryAreaElement1 = $(areaElement1);
var verticalDifference = Math.floor(jqueryAreaElement1.offset().top) - Math.floor(jqueryAreaElement2.offset().top);
if (Math.abs(verticalDifference) >= 1)
return verticalDifference;
else
return jqueryAreaElement1.offset().left - jqueryAreaElement2.offset().left;
});
}
});
})(jQuery);
/*
* jQuery File Download Plugin v1.4.2
*
* http://www.johnculviner.com
*
* Copyright (c) 2013 - John Culviner
*
* Licensed under the MIT license:
*   http://www.opensource.org/licenses/mit-license.php
*/
(function($, window){
// i'll just put them here to get evaluated on script load
var htmlSpecialCharsRegEx = /[<>&\r\n"']/gm;
var htmlSpecialCharsPlaceHolders = {
'<': 'lt;',
'>': 'gt;',
'&': 'amp;',
'\r': "#13;",
'\n': "#10;",
'"': 'quot;',
"'": 'apos;' /*single quotes just to be safe*/
};
$.extend({
//
//$.fileDownload('/path/to/url/', options)
//  see directly below for possible 'options'
fileDownload: function (fileUrl, options) {
//provide some reasonable defaults to any unspecified options below
var settings = $.extend({
//
//Requires jQuery UI: provide a message to display to the user when the file download is being prepared before the browser's dialog appears
//
preparingMessageHtml: null,
//
//Requires jQuery UI: provide a message to display to the user when a file download fails
//
failMessageHtml: null,
//
//the stock android browser straight up doesn't support file downloads initiated by a non GET: http://code.google.com/p/android/issues/detail?id=1780
//specify a message here to display if a user tries with an android browser
//if jQuery UI is installed this will be a dialog, otherwise it will be an alert
//
androidPostUnsupportedMessageHtml: "Unfortunately your Android browser doesn't support this type of file download. Please try again with a different browser.",
//
//Requires jQuery UI: options to pass into jQuery UI Dialog
//
dialogOptions: { modal: true },
//
//a function to call while the dowload is being prepared before the browser's dialog appears
//Args:
//  url - the original url attempted
//
prepareCallback: function (url) { },
//
//a function to call after a file download dialog/ribbon has appeared
//Args:
//  url - the original url attempted
//
successCallback: function (url) { },
//
//a function to call after a file download dialog/ribbon has appeared
//Args:
//  responseHtml    - the html that came back in response to the file download. this won't necessarily come back depending on the browser.
//                      in less than IE9 a cross domain error occurs because 500+ errors cause a cross domain issue due to IE subbing out the
//                      server's error message with a "helpful" IE built in message
//  url             - the original url attempted
//
failCallback: function (responseHtml, url) { },
//
// the HTTP method to use. Defaults to "GET".
//
httpMethod: "GET",
//
// if specified will perform a "httpMethod" request to the specified 'fileUrl' using the specified data.
// data must be an object (which will be $.param serialized) or already a key=value param string
//
data: null,
//
//a period in milliseconds to poll to determine if a successful file download has occured or not
//
checkInterval: 100,
//
//the cookie name to indicate if a file download has occured
//
cookieName: "fileDownload",
//
//the cookie value for the above name to indicate that a file download has occured
//
cookieValue: "true",
//
//the cookie path for above name value pair
//
cookiePath: "/",
//
//the title for the popup second window as a download is processing in the case of a mobile browser
//
popupWindowTitle: "Initiating file download...",
//
//Functionality to encode HTML entities for a POST, need this if data is an object with properties whose values contains strings with quotation marks.
//HTML entity encoding is done by replacing all &,<,>,',",\r,\n characters.
//Note that some browsers will POST the string htmlentity-encoded whilst others will decode it before POSTing.
//It is recommended that on the server, htmlentity decoding is done irrespective.
//
encodeHTMLEntities: true,
containerElement: $("body")
}, options);
var deferred = new $.Deferred();
//Setup mobile browser detection: Partial credit: http://detectmobilebrowser.com/
var userAgent = (navigator.userAgent || navigator.vendor || window.opera).toLowerCase();
var isIos;                  //has full support of features in iOS 4.0+, uses a new window to accomplish this.
var isAndroid;              //has full support of GET features in 4.0+ by using a new window. Non-GET is completely unsupported by the browser. See above for specifying a message.
var isOtherMobileBrowser;   //there is no way to reliably guess here so all other mobile devices will GET and POST to the current window.
if (/ip(ad|hone|od)/.test(userAgent)) {
isIos = true;
} else if (userAgent.indexOf('android') !== -1) {
isAndroid = true;
} else {
isOtherMobileBrowser = /avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|playbook|silk|iemobile|iris|kindle|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(userAgent) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|e\-|e\/|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(di|rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|xda(\-|2|g)|yas\-|your|zeto|zte\-/i.test(userAgent.substr(0, 4));
}
var httpMethodUpper = settings.httpMethod.toUpperCase();
if (isAndroid && httpMethodUpper !== "GET") {
//the stock android browser straight up doesn't support file downloads initiated by non GET requests: http://code.google.com/p/android/issues/detail?id=1780
if ($().dialog) {
$("<div>").html(settings.androidPostUnsupportedMessageHtml).dialog(settings.dialogOptions);
} else {
alert(settings.androidPostUnsupportedMessageHtml);
}
return deferred.reject();
}
var $preparingDialog = null;
var internalCallbacks = {
onPrepare: function (url) {
//wire up a jquery dialog to display the preparing message if specified
if (settings.preparingMessageHtml) {
$preparingDialog = $("<div>").html(settings.preparingMessageHtml).dialog(settings.dialogOptions);
} else if (settings.prepareCallback) {
settings.prepareCallback(url);
}
},
onSuccess: function (url) {
//remove the perparing message if it was specified
if ($preparingDialog) {
$preparingDialog.dialog('close');
};
settings.successCallback(url);
deferred.resolve(url);
},
onFail: function (responseHtml, url) {
//remove the perparing message if it was specified
if ($preparingDialog) {
$preparingDialog.dialog('close');
};
//wire up a jquery dialog to display the fail message if specified
if (settings.failMessageHtml) {
$("<div>").html(settings.failMessageHtml).dialog(settings.dialogOptions);
}
settings.failCallback(responseHtml, url);
deferred.reject(responseHtml, url);
}
};
internalCallbacks.onPrepare(fileUrl);
//make settings.data a param string if it exists and isn't already
if (settings.data !== null && typeof settings.data !== "string") {
settings.data = $.param(settings.data);
}
var $iframe,
downloadWindow,
formDoc,
$form;
if (httpMethodUpper === "GET") {
if (settings.data !== null) {
//need to merge any fileUrl params with the data object
var qsStart = fileUrl.indexOf('?');
if (qsStart !== -1) {
//we have a querystring in the url
if (fileUrl.substring(fileUrl.length - 1) !== "&") {
fileUrl = fileUrl + "&";
}
} else {
fileUrl = fileUrl + "?";
}
fileUrl = fileUrl + settings.data;
}
if (isIos || isAndroid) {
downloadWindow = window.open(fileUrl);
downloadWindow.document.title = settings.popupWindowTitle;
window.focus();
} else if (isOtherMobileBrowser) {
window.location(fileUrl);
} else {
$iframe = settings.containerElement.find("iframe[name='jqueryFileDownloadJS']");
if ($iframe.length != 0) {
$iframe.remove();
}
//create a temporary iframe that is used to request the fileUrl as a GET request
$iframe = $("<iframe name='jqueryFileDownloadJS'>")
.hide()
.prop("src", fileUrl)
.appendTo(settings.containerElement);
//.appendTo("body");
}
} else {
var formInnerHtml = "";
if (settings.data !== null) {
$.each(settings.data.replace(/\+/g, ' ').split("&"), function () {
var kvp = this.split("=");
var key = settings.encodeHTMLEntities ? htmlSpecialCharsEntityEncode(decodeURIComponent(kvp[0])) : decodeURIComponent(kvp[0]);
if (key) {
var value = settings.encodeHTMLEntities ? htmlSpecialCharsEntityEncode(decodeURIComponent(kvp[1])) : decodeURIComponent(kvp[1]);
formInnerHtml += '<input type="hidden" name="' + key + '" value="' + value + '" />';
}
});
}
if (isOtherMobileBrowser) {
$form = $("<form>").appendTo("body");
$form.hide()
.prop('method', settings.httpMethod)
.prop('action', fileUrl)
.html(formInnerHtml);
} else {
if (isIos) {
downloadWindow = window.open("about:blank");
downloadWindow.document.title = settings.popupWindowTitle;
formDoc = downloadWindow.document;
window.focus();
} else {
$iframe = $("<iframe style='display: none' src='about:blank'></iframe>").appendTo("body");
formDoc = getiframeDocument($iframe);
}
formDoc.write("<html><head></head><body><form method='" + settings.httpMethod + "' action='" + fileUrl + "'>" + formInnerHtml + "</form>" + settings.popupWindowTitle + "</body></html>");
$form = $(formDoc).find('form');
}
$form.submit();
}
//check if the file download has completed every checkInterval ms
setTimeout(checkFileDownloadComplete, settings.checkInterval);
function checkFileDownloadComplete() {
//has the cookie been written due to a file download occuring?
if (document.cookie.indexOf(settings.cookieName + "=" + settings.cookieValue) != -1) {
//execute specified callback
internalCallbacks.onSuccess(fileUrl);
//remove the cookie and iframe
document.cookie = settings.cookieName + "=; expires=" + new Date(1000).toUTCString() + "; path=" + settings.cookiePath;
cleanUp(false);
return;
}
//has an error occured?
//if neither containers exist below then the file download is occuring on the current window
if (downloadWindow || $iframe) {
//has an error occured?
try {
var formDoc = downloadWindow ? downloadWindow.document : getiframeDocument($iframe);
if (formDoc && formDoc.body != null && formDoc.body.innerHTML.length) {
var isFailure = true;
if ($form && $form.length) {
var $contents = $(formDoc.body).contents().first();
if ($contents.length && $contents[0] === $form[0]) {
isFailure = false;
}
}
if (isFailure) {
internalCallbacks.onFail(formDoc.body.innerHTML, fileUrl);
cleanUp(true);
return;
}
}
}
catch (err) {
//500 error less than IE9
internalCallbacks.onFail(err.message, fileUrl);
cleanUp(true);
return;
}
}
//keep checking...
setTimeout(checkFileDownloadComplete, settings.checkInterval);
}
//gets an iframes document in a cross browser compatible manner
function getiframeDocument($iframe) {
var iframeDoc = $iframe[0].contentWindow || $iframe[0].contentDocument;
if (iframeDoc && iframeDoc.document) {
iframeDoc = iframeDoc.document;
}
return iframeDoc;
}
function cleanUp(isFailure) {
setTimeout(function() {
if (downloadWindow) {
if (isAndroid) {
downloadWindow.close();
}
if (isIos) {
downloadWindow.focus(); //ios safari bug doesn't allow a window to be closed unless it is focused
if (isFailure) {
downloadWindow.close();
}
}
}
//iframe cleanup appears to randomly cause the download to fail
//not doing it seems better than failure...
//if ($iframe) {
//    $iframe.remove();
//}
}, 0);
}
function htmlSpecialCharsEntityEncode(str) {
return str.replace(htmlSpecialCharsRegEx, function(match) {
return '&' + htmlSpecialCharsPlaceHolders[match];
});
}
return deferred.promise();
}
});
})(jQuery, this);
