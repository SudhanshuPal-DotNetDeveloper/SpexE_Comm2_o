!function(e,t){"object"==typeof exports&&"undefined"!=typeof module?t(require("@firebase/app-compat"),require("@firebase/app")):"function"==typeof define&&define.amd?define(["@firebase/app-compat","@firebase/app"],t):t((e="undefined"!=typeof globalThis?globalThis:e||self).firebase,e.firebase.INTERNAL.modularAPIs)}(this,function(ye,Ae){"use strict";try{!(function(){function e(e){return e&&"object"==typeof e&&"default"in e?e:{default:e}}var t,r,o=e(ye);const n={byteToCharMap_:null,charToByteMap_:null,byteToCharMapWebSafe_:null,charToByteMapWebSafe_:null,ENCODED_VALS_BASE:"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789",get ENCODED_VALS(){return this.ENCODED_VALS_BASE+"+/="},get ENCODED_VALS_WEBSAFE(){return this.ENCODED_VALS_BASE+"-_."},HAS_NATIVE_SUPPORT:"function"==typeof atob,encodeByteArray(r,e){if(!Array.isArray(r))throw Error("encodeByteArray takes an array as a parameter");this.init_();var o=e?this.byteToCharMapWebSafe_:this.byteToCharMap_;const n=[];for(let l=0;l<r.length;l+=3){var a=r[l],i=l+1<r.length,s=i?r[l+1]:0,c=l+2<r.length,h=c?r[l+2]:0;let e=(15&s)<<2|h>>6,t=63&h;c||(t=64,i||(e=64)),n.push(o[a>>2],o[(3&a)<<4|s>>4],o[e],o[t])}return n.join("")},encodeString(e,t){return this.HAS_NATIVE_SUPPORT&&!t?btoa(e):this.encodeByteArray(function(t){const r=[];let o=0;for(let n=0;n<t.length;n++){let e=t.charCodeAt(n);e<128?r[o++]=e:(e<2048?r[o++]=e>>6|192:(55296==(64512&e)&&n+1<t.length&&56320==(64512&t.charCodeAt(n+1))?(e=65536+((1023&e)<<10)+(1023&t.charCodeAt(++n)),r[o++]=e>>18|240,r[o++]=e>>12&63|128):r[o++]=e>>12|224,r[o++]=e>>6&63|128),r[o++]=63&e|128)}return r}(e),t)},decodeString(e,t){return this.HAS_NATIVE_SUPPORT&&!t?atob(e):function(e){const t=[];let r=0,o=0;for(;r<e.length;){var n,a,i=e[r++];i<128?t[o++]=String.fromCharCode(i):191<i&&i<224?(n=e[r++],t[o++]=String.fromCharCode((31&i)<<6|63&n)):239<i&&i<365?(a=((7&i)<<18|(63&e[r++])<<12|(63&e[r++])<<6|63&e[r++])-65536,t[o++]=String.fromCharCode(55296+(a>>10)),t[o++]=String.fromCharCode(56320+(1023&a))):(n=e[r++],a=e[r++],t[o++]=String.fromCharCode((15&i)<<12|(63&n)<<6|63&a))}return t.join("")}(this.decodeStringToByteArray(e,t))},decodeStringToByteArray(e,t){this.init_();var r=t?this.charToByteMapWebSafe_:this.charToByteMap_;const o=[];for(let c=0;c<e.length;){var n=r[e.charAt(c++)],a=c<e.length?r[e.charAt(c)]:0;++c;var i=c<e.length?r[e.charAt(c)]:64;++c;var s=c<e.length?r[e.charAt(c)]:64;if(++c,null==n||null==a||null==i||null==s)throw Error();o.push(n<<2|a>>4),64!==i&&(o.push(a<<4&240|i>>2),64!==s&&o.push(i<<6&192|s))}return o},init_(){if(!this.byteToCharMap_){this.byteToCharMap_={},this.charToByteMap_={},this.byteToCharMapWebSafe_={},this.charToByteMapWebSafe_={};for(let e=0;e<this.ENCODED_VALS.length;e++)this.byteToCharMap_[e]=this.ENCODED_VALS.charAt(e),this.charToByteMap_[this.byteToCharMap_[e]]=e,this.byteToCharMapWebSafe_[e]=this.ENCODED_VALS_WEBSAFE.charAt(e),this.charToByteMapWebSafe_[this.byteToCharMapWebSafe_[e]]=e,e>=this.ENCODED_VALS_BASE.length&&(this.charToByteMap_[this.ENCODED_VALS_WEBSAFE.charAt(e)]=e,this.charToByteMapWebSafe_[this.ENCODED_VALS.charAt(e)]=e)}}},i=function(e){try{return n.decodeString(e,!0)}catch(e){console.error("base64Decode failed: ",e)}return null};function a(){return"object"==typeof indexedDB}class s{constructor(){this.reject=()=>{},this.resolve=()=>{},this.promise=new Promise((e,t)=>{this.resolve=e,this.reject=t})}wrapCallback(r){return(e,t)=>{e?this.reject(e):this.resolve(t),"function"==typeof r&&(this.promise.catch(()=>{}),1===r.length?r(e):r(e,t))}}}class c extends Error{constructor(e,t,r){super(t),this.code=e,this.customData=r,this.name="FirebaseError",Object.setPrototypeOf(this,c.prototype),Error.captureStackTrace&&Error.captureStackTrace(this,h.prototype.create)}}class h{constructor(e,t,r){this.service=e,this.serviceName=t,this.errors=r}create(e,...t){var o,r=t[0]||{},n=`${this.service}/${e}`,a=this.errors[e],a=a?(o=r,a.replace(l,(e,t)=>{var r=o[t];return null!=r?String(r):`<${t}?>`})):"Error",a=`${this.serviceName}: ${a} (${n}).`;return new c(n,a,r)}}const l=/\{\$([^}]+)}/g;function p(e){return JSON.parse(e)}function u(e){const t=function(e){let t={},r={},o={},n="";try{var a=e.split(".");t=p(i(a[0])||""),r=p(i(a[1])||""),n=a[2],o=r.d||{},delete r.d}catch(e){}return{header:t,claims:r,data:o,signature:n}}(e).claims;return"object"==typeof t&&t.hasOwnProperty("iat")?t.iat:null}function d(){return"xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g,e=>{const t=16*Math.random()|0,r="x"===e?t:3&t|8;return r.toString(16)})}const g=144e5,f=.5;class v{constructor(e,t,r){this.name=e,this.instanceFactory=t,this.type=r,this.multipleInstances=!1,this.serviceProps={},this.instantiationMode="LAZY",this.onInstanceCreated=null}setInstantiationMode(e){return this.instantiationMode=e,this}setMultipleInstances(e){return this.multipleInstances=e,this}setServiceProps(e){return this.serviceProps=e,this}setInstanceCreatedCallback(e){return this.onInstanceCreated=e,this}}(r=t=t||{})[r.DEBUG=0]="DEBUG",r[r.VERBOSE=1]="VERBOSE",r[r.INFO=2]="INFO",r[r.WARN=3]="WARN",r[r.ERROR=4]="ERROR",r[r.SILENT=5]="SILENT";const E={debug:t.DEBUG,verbose:t.VERBOSE,info:t.INFO,warn:t.WARN,error:t.ERROR,silent:t.SILENT},_=t.INFO,w={[t.DEBUG]:"log",[t.VERBOSE]:"log",[t.INFO]:"info",[t.WARN]:"warn",[t.ERROR]:"error"},m=(e,t,...r)=>{if(!(t<e.logLevel)){var o=(new Date).toISOString(),n=w[t];if(!n)throw new Error(`Attempted to log a message with an invalid logType (value: ${t})`);console[n](`[${o}]  ${e.name}:`,...r)}};const b=new Map,k={activated:!1,tokenObservers:[]},y={initialized:!1,enabled:!1};function A(e){return b.get(e)||Object.assign({},k)}const T="https://content-firebaseappcheck.googleapis.com/v1",C="exchangeDebugToken",S={OFFSET_DURATION:3e5,RETRIAL_MIN_WAIT:3e4,RETRIAL_MAX_WAIT:96e4};class R{constructor(e,t,r,o,n){if(this.operation=e,this.retryPolicy=t,this.getWaitDuration=r,this.lowerBound=o,this.upperBound=n,this.pending=null,n<(this.nextErrorWaitInterval=o))throw new Error("Proactive refresh lower bound greater than upper bound!")}start(){this.nextErrorWaitInterval=this.lowerBound,this.process(!0).catch(()=>{})}stop(){this.pending&&(this.pending.reject("cancelled"),this.pending=null)}isRunning(){return!!this.pending}async process(e){this.stop();try{this.pending=new s,t=this.getNextRun(e),await new Promise(e=>{setTimeout(e,t)}),this.pending.resolve(),await this.pending.promise,this.pending=new s,await this.operation(),this.pending.resolve(),await this.pending.promise,this.process(!0).catch(()=>{})}catch(e){this.retryPolicy(e)?this.process(!1).catch(()=>{}):this.stop()}var t}getNextRun(e){if(e)return this.nextErrorWaitInterval=this.lowerBound,this.getWaitDuration();var t=this.nextErrorWaitInterval;return this.nextErrorWaitInterval*=2,this.nextErrorWaitInterval>this.upperBound&&(this.nextErrorWaitInterval=this.upperBound),t}}const P=new h("appCheck","AppCheck",{"already-initialized":"You have already called initializeAppCheck() for FirebaseApp {$appName} with different options. To avoid this error, call initializeAppCheck() with the same options as when it was originally called. This will return the already initialized instance.","use-before-activation":"App Check is being used before initializeAppCheck() is called for FirebaseApp {$appName}. Call initializeAppCheck() before instantiating other Firebase services.","fetch-network-error":"Fetch failed to connect to a network. Check Internet connection. Original error: {$originalErrorMessage}.","fetch-parse-error":"Fetch client could not parse response. Original error: {$originalErrorMessage}.","fetch-status-error":"Fetch server returned an HTTP error status. HTTP status: {$httpStatus}.","storage-open":"Error thrown when opening storage. Original error: {$originalErrorMessage}.","storage-get":"Error thrown when reading from storage. Original error: {$originalErrorMessage}.","storage-set":"Error thrown when writing to storage. Original error: {$originalErrorMessage}.","recaptcha-error":"ReCAPTCHA error.",throttled:"Requests throttled due to {$httpStatus} error. Attempts allowed again after {$time}"});function I(e=!1){var t;return e?null===(t=self.grecaptcha)||void 0===t?void 0:t.enterprise:self.grecaptcha}function D(e){if(!A(e).activated)throw P.create("use-before-activation",{appName:e.name})}function O(e){var t=Math.round(e/1e3),r=Math.floor(t/86400),o=Math.floor((t-3600*r*24)/3600),n=Math.floor((t-3600*r*24-3600*o)/60),t=t-3600*r*24-3600*o-60*n;let a="";return r&&(a+=x(r)+"d:"),o&&(a+=x(o)+"h:"),a+=x(n)+"m:"+x(t)+"s",a}function x(e){return 0===e?"00":10<=e?e.toString():"0"+e}async function N({url:e,body:t},r){const o={"Content-Type":"application/json"},n=r.getImmediate({optional:!0});!n||(c=await n.getHeartbeatsHeader())&&(o["X-Firebase-Client"]=c);var a={method:"POST",body:JSON.stringify(t),headers:o};let i;try{i=await fetch(e,a)}catch(e){throw P.create("fetch-network-error",{originalErrorMessage:null===e||void 0===e?void 0:e.message})}if(200!==i.status)throw P.create("fetch-status-error",{httpStatus:i.status});let s;try{s=await i.json()}catch(e){throw P.create("fetch-parse-error",{originalErrorMessage:null===e||void 0===e?void 0:e.message})}var c=s.ttl.match(/^([\d.]+)(s)$/);if(!c||!c[2]||isNaN(Number(c[1])))throw P.create("fetch-parse-error",{originalErrorMessage:"ttl field (timeToLive) is not in standard Protobuf Duration "+`format: ${s.ttl}`});a=1e3*Number(c[1]),c=Date.now();return{token:s.token,expireTimeMillis:c+a,issuedAtTimeMillis:c}}const M="firebase-app-check-database",L=1,B="firebase-app-check-store",H="debug-token";let $=null;function j(){return $||($=new Promise((t,r)=>{try{const e=indexedDB.open(M,L);e.onsuccess=e=>{t(e.target.result)},e.onerror=e=>{var t;r(P.create("storage-open",{originalErrorMessage:null===(t=e.target.error)||void 0===t?void 0:t.message}))},e.onupgradeneeded=e=>{const t=e.target.result;0===e.oldVersion&&t.createObjectStore(B,{keyPath:"compositeKey"})}}catch(e){r(P.create("storage-open",{originalErrorMessage:null===e||void 0===e?void 0:e.message}))}}),$)}async function W(e,t){const r=await j(),o=r.transaction(B,"readwrite"),n=o.objectStore(B),a=n.put({compositeKey:e,value:t});return new Promise((t,r)=>{a.onsuccess=e=>{t()},o.onerror=e=>{var t;r(P.create("storage-set",{originalErrorMessage:null===(t=e.target.error)||void 0===t?void 0:t.message}))}})}async function F(e){const t=await j(),n=t.transaction(B,"readonly"),r=n.objectStore(B),a=r.get(e);return new Promise((r,o)=>{a.onsuccess=e=>{var t=e.target.result;r(t?t.value:void 0)},n.onerror=e=>{var t;o(P.create("storage-get",{originalErrorMessage:null===(t=e.target.error)||void 0===t?void 0:t.message}))}})}function V(e){return`${e.options.appId}-${e.name}`}const K=new class{constructor(e){this.name=e,this._logLevel=_,this._logHandler=m,this._userLogHandler=null}get logLevel(){return this._logLevel}set logLevel(e){if(!(e in t))throw new TypeError(`Invalid value "${e}" assigned to \`logLevel\``);this._logLevel=e}setLogLevel(e){this._logLevel="string"==typeof e?E[e]:e}get logHandler(){return this._logHandler}set logHandler(e){if("function"!=typeof e)throw new TypeError("Value assigned to `logHandler` must be a function");this._logHandler=e}get userLogHandler(){return this._userLogHandler}set userLogHandler(e){this._userLogHandler=e}debug(...e){this._userLogHandler&&this._userLogHandler(this,t.DEBUG,...e),this._logHandler(this,t.DEBUG,...e)}log(...e){this._userLogHandler&&this._userLogHandler(this,t.VERBOSE,...e),this._logHandler(this,t.VERBOSE,...e)}info(...e){this._userLogHandler&&this._userLogHandler(this,t.INFO,...e),this._logHandler(this,t.INFO,...e)}warn(...e){this._userLogHandler&&this._userLogHandler(this,t.WARN,...e),this._logHandler(this,t.WARN,...e)}error(...e){this._userLogHandler&&this._userLogHandler(this,t.ERROR,...e),this._logHandler(this,t.ERROR,...e)}}("@firebase/app-check");async function z(t){if(a()){let e=void 0;try{e=await F(V(t))}catch(e){K.warn(`Failed to read token from IndexedDB. Error: ${e}`)}return e}}function U(e,t){return a()?W(V(e),t).catch(e=>{K.warn(`Failed to write token to IndexedDB. Error: ${e}`)}):Promise.resolve()}async function q(){let e=void 0;try{e=await F(H)}catch(e){}if(e)return e;var t,r=d();return t=r,W(H,t).catch(e=>K.warn(`Failed to persist debug token to IndexedDB. Error: ${e}`)),r}function G(){return y.enabled}async function X(){var e=y;if(e.enabled&&e.token)return e.token.promise;throw Error(`
            Can't get debug token in production mode.
        `)}function J(){var e=function(){if("undefined"!=typeof self)return self;if("undefined"!=typeof window)return window;if("undefined"!=typeof global)return global;throw new Error("Unable to locate global object.")}();const t=y;if(t.initialized=!0,"string"==typeof e.FIREBASE_APPCHECK_DEBUG_TOKEN||!0===e.FIREBASE_APPCHECK_DEBUG_TOKEN){t.enabled=!0;const r=new s;t.token=r,"string"==typeof e.FIREBASE_APPCHECK_DEBUG_TOKEN?r.resolve(e.FIREBASE_APPCHECK_DEBUG_TOKEN):r.resolve(q())}}const Y={error:"UNKNOWN_ERROR"};async function Z(e,t=!1){var r=e.app;D(r);const o=A(r);let n=o.token,a=void 0;if(n&&!oe(n)&&(o.token=void 0,n=void 0),n||(s=await o.cachedTokenPromise)&&(oe(s)?n=s:await U(r,void 0)),!t&&n&&oe(n))return{token:n.token};let i=!1;if(G()){o.exchangeTokenPromise||(o.exchangeTokenPromise=N(function(e,t){var{projectId:r,appId:o,apiKey:n}=e.options;return{url:`${T}/projects/${r}/apps/${o}:${C}?key=${n}`,body:{debug_token:t}}}(r,await X()),e.heartbeatServiceProvider).finally(()=>{o.exchangeTokenPromise=void 0}),i=!0);var s=await o.exchangeTokenPromise;return await U(r,s),{token:(o.token=s).token}}try{o.exchangeTokenPromise||(o.exchangeTokenPromise=o.provider.getToken().finally(()=>{o.exchangeTokenPromise=void 0}),i=!0),n=await A(r).exchangeTokenPromise}catch(e){"appCheck/throttled"===e.code?K.warn(e.message):K.error(e),a=e}let c;return n?a?c=oe(n)?{token:n.token,internalError:a}:ne(a):(c={token:n.token},o.token=n,await U(r,n)):c=ne(a),i&&re(r,c),c}function Q(e,t,r,o){var n=e["app"];const a=A(n);n={next:r,error:o,type:t};if(a.tokenObservers=[...a.tokenObservers,n],a.token&&oe(a.token)){const i=a.token;Promise.resolve().then(()=>{r({token:i.token}),te(e)}).catch(()=>{})}a.cachedTokenPromise.then(()=>te(e))}function ee(e,t){const r=A(e);var o=r.tokenObservers.filter(e=>e.next!==t);0===o.length&&r.tokenRefresher&&r.tokenRefresher.isRunning()&&r.tokenRefresher.stop(),r.tokenObservers=o}function te(e){var t=e["app"];const r=A(t);let o=r.tokenRefresher;o||(o=function(r){const o=r["app"];return new R(async()=>{var e=A(o);let t;if(t=e.token?await Z(r,!0):await Z(r),t.error)throw t.error;if(t.internalError)throw t.internalError},()=>!0,()=>{var e=A(o);if(e.token){var t=e.token.issuedAtTimeMillis+.5*(e.token.expireTimeMillis-e.token.issuedAtTimeMillis)+3e5,e=e.token.expireTimeMillis-3e5,t=Math.min(t,e);return Math.max(0,t-Date.now())}return 0},S.RETRIAL_MIN_WAIT,S.RETRIAL_MAX_WAIT)}(e),r.tokenRefresher=o),!o.isRunning()&&r.isTokenAutoRefreshEnabled&&o.start()}function re(e,t){for(const r of A(e).tokenObservers)try{"EXTERNAL"===r.type&&null!=t.error?r.error(t.error):r.next(t)}catch(e){}}function oe(e){return 0<e.expireTimeMillis-Date.now()}function ne(e){return{token:(t=Y,n.encodeString(JSON.stringify(t),!1)),error:e};var t}class ae{constructor(e,t){this.app=e,this.heartbeatServiceProvider=t}_delete(){var e=A(this.app)["tokenObservers"];for(const t of e)ee(this.app,t.next);return Promise.resolve()}}const ie="https://www.google.com/recaptcha/api.js",se="https://www.google.com/recaptcha/enterprise.js";function ce(t,r){const o=new s,e=A(t);e.reCAPTCHAState={initialized:o};const n=pe(t);var a=I(!1);return a?le(t,r,a,n,o):function(e){const t=document.createElement("script");t.src=ie,t.onload=e,document.head.appendChild(t)}(()=>{var e=I(!1);if(!e)throw new Error("no recaptcha");le(t,r,e,n,o)}),o.promise}function he(t,r){const o=new s,e=A(t);e.reCAPTCHAState={initialized:o};const n=pe(t);var a=I(!0);return a?le(t,r,a,n,o):function(e){const t=document.createElement("script");t.src=se,t.onload=e,document.head.appendChild(t)}(()=>{var e=I(!0);if(!e)throw new Error("no recaptcha");le(t,r,e,n,o)}),o.promise}function le(e,t,r,o,n){r.ready(()=>{!function(e,t,r,o){const n=r.render(o,{sitekey:t,size:"invisible"}),a=A(e);a.reCAPTCHAState=Object.assign(Object.assign({},a.reCAPTCHAState),{widgetId:n})}(e,t,r,o),n.resolve(r)})}function pe(e){var t=`fire_app_check_${e.name}`;const r=document.createElement("div");return r.id=t,r.style.display="none",document.body.appendChild(r),t}async function ue(o){D(o);const n=await A(o).reCAPTCHAState.initialized.promise;return new Promise((e,t)=>{const r=A(o).reCAPTCHAState;n.ready(()=>{e(n.execute(r.widgetId,{action:"fire_app_check"}))})})}class de{constructor(e){this._siteKey=e,this._throttleData=null}async getToken(){Ee(this._throttleData);var t=await ue(this._app).catch(e=>{throw P.create("recaptcha-error")});let e;try{e=await N(function(e,t){var{projectId:r,appId:o,apiKey:n}=e.options;return{url:`${T}/projects/${r}/apps/${o}:exchangeRecaptchaV3Token?key=${n}`,body:{recaptcha_v3_token:t}}}(this._app,t),this._heartbeatServiceProvider)}catch(e){throw null!==(t=e.code)&&void 0!==t&&t.includes("fetch-status-error")?(this._throttleData=ve(Number(null===(t=e.customData)||void 0===t?void 0:t.httpStatus),this._throttleData),P.create("throttled",{time:O(this._throttleData.allowRequestsAfter-Date.now()),httpStatus:this._throttleData.httpStatus})):e}return this._throttleData=null,e}initialize(e){this._app=e,this._heartbeatServiceProvider=Ae._getProvider(e,"heartbeat"),ce(e,this._siteKey).catch(()=>{})}isEqual(e){return e instanceof de&&this._siteKey===e._siteKey}}class ge{constructor(e){this._siteKey=e,this._throttleData=null}async getToken(){Ee(this._throttleData);var t=await ue(this._app).catch(e=>{throw P.create("recaptcha-error")});let e;try{e=await N(function(e,t){var{projectId:r,appId:o,apiKey:n}=e.options;return{url:`${T}/projects/${r}/apps/${o}:exchangeRecaptchaEnterpriseToken?key=${n}`,body:{recaptcha_enterprise_token:t}}}(this._app,t),this._heartbeatServiceProvider)}catch(e){throw null!==(t=e.code)&&void 0!==t&&t.includes("fetch-status-error")?(this._throttleData=ve(Number(null===(t=e.customData)||void 0===t?void 0:t.httpStatus),this._throttleData),P.create("throttled",{time:O(this._throttleData.allowRequestsAfter-Date.now()),httpStatus:this._throttleData.httpStatus})):e}return this._throttleData=null,e}initialize(e){this._app=e,this._heartbeatServiceProvider=Ae._getProvider(e,"heartbeat"),he(e,this._siteKey).catch(()=>{})}isEqual(e){return e instanceof ge&&this._siteKey===e._siteKey}}class fe{constructor(e){this._customProviderOptions=e}async getToken(){var e=await this._customProviderOptions.getToken(),t=u(e.token),t=null!==t&&t<Date.now()&&0<t?1e3*t:Date.now();return Object.assign(Object.assign({},e),{issuedAtTimeMillis:t})}initialize(e){this._app=e}isEqual(e){return e instanceof fe&&this._customProviderOptions.getToken.toString()===e._customProviderOptions.getToken.toString()}}function ve(e,t){if(404===e||403===e)return{backoffCount:1,allowRequestsAfter:Date.now()+864e5,httpStatus:e};var r,o,n=t?t.backoffCount:0,o=(t=2,r=1e3*Math.pow(t,n),o=Math.round(f*r*(Math.random()-.5)*2),Math.min(g,r+o));return{backoffCount:n+1,allowRequestsAfter:Date.now()+o,httpStatus:e}}function Ee(e){if(e&&Date.now()-e.allowRequestsAfter<=0)throw P.create("throttled",{time:O(e.allowRequestsAfter-Date.now()),httpStatus:e.httpStatus})}function _e(e=Ae.getApp(),t){var r;e=(r=e)&&r._delegate?r._delegate:r;const o=Ae._getProvider(e,"app-check");if(y.initialized||J(),G()&&X().then(e=>console.log(`App Check debug token: ${e}. You will need to add it to your app's App Check settings in the Firebase console for it to work.`)),o.isInitialized()){var n=o.getImmediate();const a=o.getOptions();if(a.isTokenAutoRefreshEnabled===t.isTokenAutoRefreshEnabled&&a.provider.isEqual(t.provider))return n;throw P.create("already-initialized",{appName:e.name})}n=o.initialize({options:t});return function(t,e,r){const o=function(e,t){return b.set(e,t),b.get(e)}(t,Object.assign({},k));o.activated=!0,o.provider=e,o.cachedTokenPromise=z(t).then(e=>(e&&oe(e)&&(o.token=e,re(t,{token:e.token})),e)),o.isTokenAutoRefreshEnabled=void 0===r?t.automaticDataCollectionEnabled:r,o.provider.initialize(t)}(e,t.provider,t.isTokenAutoRefreshEnabled),A(e).isTokenAutoRefreshEnabled&&Q(n,"INTERNAL",()=>{}),n}const we="app-check-internal";Ae._registerComponent(new v("app-check",e=>{var t,r=e.getProvider("app").getImmediate(),o=e.getProvider("heartbeat");return t=r,e=o,new ae(t,e)},"PUBLIC").setInstantiationMode("EXPLICIT").setInstanceCreatedCallback((e,t,r)=>{e.getProvider(we).initialize()})),Ae._registerComponent(new v(we,e=>{var t,r=e.getProvider("app-check").getImmediate();return t=r,{getToken:e=>Z(t,e),addTokenListener:e=>Q(t,"INTERNAL",e),removeTokenListener:e=>ee(t.app,e)}},"PUBLIC").setInstantiationMode("EXPLICIT")),Ae.registerVersion("@firebase/app-check","0.5.17");const me=new h("appCheck","AppCheck",{"use-before-activation":"App Check is being used before activate() is called for FirebaseApp {$appName}. Call activate() before instantiating other Firebase services."});class be{constructor(e){this.app=e}activate(e,t){let r;r="string"==typeof e?new de(e):e instanceof ge||e instanceof de||e instanceof fe?e:new fe({getToken:e.getToken}),this._delegate=_e(this.app,{provider:r,isTokenAutoRefreshEnabled:t})}setTokenAutoRefreshEnabled(e){if(!this._delegate)throw me.create("use-before-activation",{appName:this.app.name});!function(e,t){const r=A(e.app);r.tokenRefresher&&(!0===t?r.tokenRefresher.start():r.tokenRefresher.stop()),r.isTokenAutoRefreshEnabled=t}(this._delegate,e)}getToken(e){if(!this._delegate)throw me.create("use-before-activation",{appName:this.app.name});return async function(e,t){var r=await Z(e,t);if(r.error)throw r.error;return{token:r.token}}(this._delegate,e)}onTokenChanged(e,t,r){if(!this._delegate)throw me.create("use-before-activation",{appName:this.app.name});return function(e,t,r){let o=()=>{},n=()=>{};return o=null!=t.next?t.next.bind(t):t,null!=t.error?n=t.error.bind(t):r&&(n=r),Q(e,"EXTERNAL",o,n),()=>ee(e.app,o)}(this._delegate,e,t)}}const ke=e=>{var t=e.getProvider("app-compat").getImmediate();return new be(t)};o.default.INTERNAL.registerComponent(new v("appCheck-compat",ke,"PUBLIC").setServiceProps({ReCaptchaEnterpriseProvider:ge,ReCaptchaV3Provider:de,CustomProvider:fe})),o.default.registerVersion("@firebase/app-check-compat","0.2.17")}).apply(this,arguments)}catch(e){throw console.error(e),new Error("Cannot instantiate firebase-app-check-compat.js - be sure to load firebase-app.js first.")}});
//# sourceMappingURL=firebase-app-check-compat.js.map
