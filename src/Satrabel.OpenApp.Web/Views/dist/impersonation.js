(function(n){var r={};function o(e){if(r[e]){return r[e].exports}var t=r[e]={i:e,l:false,exports:{}};n[e].call(t.exports,t,t.exports,o);t.l=true;return t.exports}o.m=n;o.c=r;o.d=function(e,t,n){if(!o.o(e,t)){Object.defineProperty(e,t,{enumerable:true,get:n})}};o.r=function(e){if(typeof Symbol!=="undefined"&&Symbol.toStringTag){Object.defineProperty(e,Symbol.toStringTag,{value:"Module"})}Object.defineProperty(e,"__esModule",{value:true})};o.t=function(t,e){if(e&1)t=o(t);if(e&8)return t;if(e&4&&typeof t==="object"&&t&&t.__esModule)return t;var n=Object.create(null);o.r(n);Object.defineProperty(n,"default",{enumerable:true,value:t});if(e&2&&typeof t!="string")for(var r in t)o.d(n,r,function(e){return t[e]}.bind(null,r));return n};o.n=function(t){var e=t&&t.__esModule?function e(){return t["default"]}:function e(){return t};o.d(e,"a",e);return e};o.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)};o.p="dist/";return o(o.s=14)})({0:function(e,t,n){e.exports=n(2)(2)},1:function(e,t,n){"use strict";n.d(t,"a",function(){return r});function r(e,t,n,r,o,i,a,s){var u=typeof e==="function"?e.options:e;if(t){u.render=t;u.staticRenderFns=n;u._compiled=true}if(r){u.functional=true}if(i){u._scopeId="data-v-"+i}var l;if(a){l=function(e){e=e||this.$vnode&&this.$vnode.ssrContext||this.parent&&this.parent.$vnode&&this.parent.$vnode.ssrContext;if(!e&&typeof __VUE_SSR_CONTEXT__!=="undefined"){e=__VUE_SSR_CONTEXT__}if(o){o.call(this,e)}if(e&&e._registeredComponents){e._registeredComponents.add(a)}};u._ssrRegister=l}else if(o){l=s?function(){o.call(this,(u.functional?this.parent:this).$root.$options.shadowRoot)}:o}if(l){if(u.functional){u._injectStyles=l;var f=u.render;u.render=function e(t,n){l.call(n);return f(t,n)}}else{var c=u.beforeCreate;u.beforeCreate=c?[].concat(c,l):[l]}}return{exports:e,options:u}}},14:function(e,t,n){"use strict";n.r(t);var r=n(0);var o=function(){var e=this;var t=e.$createElement;var n=e._self._c||t;return n("el-tooltip",{attrs:{content:"Impersonate",placement:"top"}},[n("el-button",{attrs:{icon:"el-icon-share",size:"small"},on:{click:e.impersonate}})],1)};var i=[];o._withStripped=true;var a={name:"oa-userimpersonation",props:{id:{},tenantId:{}},data:function e(){return{}},created:function e(){},computed:{},methods:{impersonate:function e(){abp.services.app.impersonate.impersonate({tenantId:this.tenantId,userId:this.id}).done(function(e){window.location=e}).always(function(){self.loading=false})}}};var s=a;var u=n(1);var l=Object(u["a"])(s,o,i,false,null,null,null);if(false){var f}l.options.__file="ClientApp/shared/userimpersonation.vue";var c=l.exports;var p=function(){var e=this;var t=e.$createElement;var n=e._self._c||t;return n("el-tooltip",{attrs:{content:"Impersonate",placement:"top"}},[n("el-button",{attrs:{icon:"el-icon-share",size:"small"},on:{click:e.impersonate}})],1)};var d=[];p._withStripped=true;var v={name:"oa-userimpersonation",props:{id:{},tenantId:{}},data:function e(){return{}},created:function e(){},computed:{},methods:{impersonate:function e(){abp.services.app.impersonate.impersonateTenant(this.id).done(function(e){window.location=e}).always(function(){self.loading=false})}}};var m=v;var _=Object(u["a"])(m,p,d,false,null,null,null);if(false){var h}_.options.__file="ClientApp/shared/tenantimpersonation.vue";var b=_.exports;r["default"].component("oa-userimpersonation",c);r["default"].component("oa-tenantimpersonation",b)},2:function(e,t){e.exports=vendor_740e84b1760e53637ff6}});