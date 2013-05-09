﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TesseractRunner.TranslatorService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://api.microsofttranslator.com/v1/soap.svc", ConfigurationName="TranslatorService.LanguageService")]
    public interface LanguageService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/GetLanguages", ReplyAction="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/GetLanguagesRespon" +
            "se")]
        TesseractRunner.TranslatorService.GetLanguagesResponse GetLanguages(TesseractRunner.TranslatorService.GetLanguagesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/GetLanguages", ReplyAction="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/GetLanguagesRespon" +
            "se")]
        System.Threading.Tasks.Task<TesseractRunner.TranslatorService.GetLanguagesResponse> GetLanguagesAsync(TesseractRunner.TranslatorService.GetLanguagesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/GetLanguageNames", ReplyAction="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/GetLanguageNamesRe" +
            "sponse")]
        TesseractRunner.TranslatorService.GetLanguageNamesResponse GetLanguageNames(TesseractRunner.TranslatorService.GetLanguageNamesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/GetLanguageNames", ReplyAction="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/GetLanguageNamesRe" +
            "sponse")]
        System.Threading.Tasks.Task<TesseractRunner.TranslatorService.GetLanguageNamesResponse> GetLanguageNamesAsync(TesseractRunner.TranslatorService.GetLanguageNamesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/Detect", ReplyAction="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/DetectResponse")]
        TesseractRunner.TranslatorService.DetectResponse Detect(TesseractRunner.TranslatorService.DetectRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/Detect", ReplyAction="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/DetectResponse")]
        System.Threading.Tasks.Task<TesseractRunner.TranslatorService.DetectResponse> DetectAsync(TesseractRunner.TranslatorService.DetectRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/Translate", ReplyAction="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/TranslateResponse")]
        TesseractRunner.TranslatorService.TranslateResponse Translate(TesseractRunner.TranslatorService.TranslateRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/Translate", ReplyAction="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/TranslateResponse")]
        System.Threading.Tasks.Task<TesseractRunner.TranslatorService.TranslateResponse> TranslateAsync(TesseractRunner.TranslatorService.TranslateRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetLanguages", WrapperNamespace="http://api.microsofttranslator.com/v1/soap.svc", IsWrapped=true)]
    public partial class GetLanguagesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://api.microsofttranslator.com/v1/soap.svc", Order=0)]
        public string appId;
        
        public GetLanguagesRequest() {
        }
        
        public GetLanguagesRequest(string appId) {
            this.appId = appId;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetLanguagesResponse", WrapperNamespace="http://api.microsofttranslator.com/v1/soap.svc", IsWrapped=true)]
    public partial class GetLanguagesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://api.microsofttranslator.com/v1/soap.svc", Order=0)]
        public string[] GetLanguagesResult;
        
        public GetLanguagesResponse() {
        }
        
        public GetLanguagesResponse(string[] GetLanguagesResult) {
            this.GetLanguagesResult = GetLanguagesResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetLanguageNames", WrapperNamespace="http://api.microsofttranslator.com/v1/soap.svc", IsWrapped=true)]
    public partial class GetLanguageNamesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://api.microsofttranslator.com/v1/soap.svc", Order=0)]
        public string appId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://api.microsofttranslator.com/v1/soap.svc", Order=1)]
        public string locale;
        
        public GetLanguageNamesRequest() {
        }
        
        public GetLanguageNamesRequest(string appId, string locale) {
            this.appId = appId;
            this.locale = locale;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetLanguageNamesResponse", WrapperNamespace="http://api.microsofttranslator.com/v1/soap.svc", IsWrapped=true)]
    public partial class GetLanguageNamesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://api.microsofttranslator.com/v1/soap.svc", Order=0)]
        public string[] GetLanguageNamesResult;
        
        public GetLanguageNamesResponse() {
        }
        
        public GetLanguageNamesResponse(string[] GetLanguageNamesResult) {
            this.GetLanguageNamesResult = GetLanguageNamesResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Detect", WrapperNamespace="http://api.microsofttranslator.com/v1/soap.svc", IsWrapped=true)]
    public partial class DetectRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://api.microsofttranslator.com/v1/soap.svc", Order=0)]
        public string appId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://api.microsofttranslator.com/v1/soap.svc", Order=1)]
        public string text;
        
        public DetectRequest() {
        }
        
        public DetectRequest(string appId, string text) {
            this.appId = appId;
            this.text = text;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DetectResponse", WrapperNamespace="http://api.microsofttranslator.com/v1/soap.svc", IsWrapped=true)]
    public partial class DetectResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://api.microsofttranslator.com/v1/soap.svc", Order=0)]
        public string DetectResult;
        
        public DetectResponse() {
        }
        
        public DetectResponse(string DetectResult) {
            this.DetectResult = DetectResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Translate", WrapperNamespace="http://api.microsofttranslator.com/v1/soap.svc", IsWrapped=true)]
    public partial class TranslateRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://api.microsofttranslator.com/v1/soap.svc", Order=0)]
        public string appId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://api.microsofttranslator.com/v1/soap.svc", Order=1)]
        public string text;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://api.microsofttranslator.com/v1/soap.svc", Order=2)]
        public string from;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://api.microsofttranslator.com/v1/soap.svc", Order=3)]
        public string to;
        
        public TranslateRequest() {
        }
        
        public TranslateRequest(string appId, string text, string from, string to) {
            this.appId = appId;
            this.text = text;
            this.from = from;
            this.to = to;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TranslateResponse", WrapperNamespace="http://api.microsofttranslator.com/v1/soap.svc", IsWrapped=true)]
    public partial class TranslateResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://api.microsofttranslator.com/v1/soap.svc", Order=0)]
        public string TranslateResult;
        
        public TranslateResponse() {
        }
        
        public TranslateResponse(string TranslateResult) {
            this.TranslateResult = TranslateResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface LanguageServiceChannel : TesseractRunner.TranslatorService.LanguageService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LanguageServiceClient : System.ServiceModel.ClientBase<TesseractRunner.TranslatorService.LanguageService>, TesseractRunner.TranslatorService.LanguageService {
        
        public LanguageServiceClient() {
        }
        
        public LanguageServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LanguageServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LanguageServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LanguageServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TesseractRunner.TranslatorService.GetLanguagesResponse GetLanguages(TesseractRunner.TranslatorService.GetLanguagesRequest request) {
            return base.Channel.GetLanguages(request);
        }
        
        public System.Threading.Tasks.Task<TesseractRunner.TranslatorService.GetLanguagesResponse> GetLanguagesAsync(TesseractRunner.TranslatorService.GetLanguagesRequest request) {
            return base.Channel.GetLanguagesAsync(request);
        }
        
        public TesseractRunner.TranslatorService.GetLanguageNamesResponse GetLanguageNames(TesseractRunner.TranslatorService.GetLanguageNamesRequest request) {
            return base.Channel.GetLanguageNames(request);
        }
        
        public System.Threading.Tasks.Task<TesseractRunner.TranslatorService.GetLanguageNamesResponse> GetLanguageNamesAsync(TesseractRunner.TranslatorService.GetLanguageNamesRequest request) {
            return base.Channel.GetLanguageNamesAsync(request);
        }
        
        public TesseractRunner.TranslatorService.DetectResponse Detect(TesseractRunner.TranslatorService.DetectRequest request) {
            return base.Channel.Detect(request);
        }
        
        public System.Threading.Tasks.Task<TesseractRunner.TranslatorService.DetectResponse> DetectAsync(TesseractRunner.TranslatorService.DetectRequest request) {
            return base.Channel.DetectAsync(request);
        }
        
        public TesseractRunner.TranslatorService.TranslateResponse Translate(TesseractRunner.TranslatorService.TranslateRequest request) {
            return base.Channel.Translate(request);
        }
        
        public System.Threading.Tasks.Task<TesseractRunner.TranslatorService.TranslateResponse> TranslateAsync(TesseractRunner.TranslatorService.TranslateRequest request) {
            return base.Channel.TranslateAsync(request);
        }
    }
}