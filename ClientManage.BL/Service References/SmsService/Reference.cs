﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientManage.BL.SmsService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://inforu.co.il/api/v2/asmx/SendMessage/", ConfigurationName="SmsService.SendMessageSoap")]
    public interface SendMessageSoap {
        
        // CODEGEN: Generating message contract since element name userName from namespace http://inforu.co.il/api/v2/asmx/SendMessage/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://inforu.co.il/api/v2/asmx/SendMessage/SendSms", ReplyAction="*")]
        ClientManage.BL.SmsService.SendSmsResponse SendSms(ClientManage.BL.SmsService.SendSmsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://inforu.co.il/api/v2/asmx/SendMessage/SendSms", ReplyAction="*")]
        System.Threading.Tasks.Task<ClientManage.BL.SmsService.SendSmsResponse> SendSmsAsync(ClientManage.BL.SmsService.SendSmsRequest request);
        
        // CODEGEN: Generating message contract since element name userName from namespace http://inforu.co.il/api/v2/asmx/SendMessage/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://inforu.co.il/api/v2/asmx/SendMessage/SendSmsDetailed", ReplyAction="*")]
        ClientManage.BL.SmsService.SendSmsDetailedResponse SendSmsDetailed(ClientManage.BL.SmsService.SendSmsDetailedRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://inforu.co.il/api/v2/asmx/SendMessage/SendSmsDetailed", ReplyAction="*")]
        System.Threading.Tasks.Task<ClientManage.BL.SmsService.SendSmsDetailedResponse> SendSmsDetailedAsync(ClientManage.BL.SmsService.SendSmsDetailedRequest request);
        
        // CODEGEN: Generating message contract since element name xmlData from namespace http://inforu.co.il/api/v2/asmx/SendMessage/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://inforu.co.il/api/v2/asmx/SendMessage/SendSmsXml", ReplyAction="*")]
        ClientManage.BL.SmsService.SendSmsXmlResponse SendSmsXml(ClientManage.BL.SmsService.SendSmsXmlRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://inforu.co.il/api/v2/asmx/SendMessage/SendSmsXml", ReplyAction="*")]
        System.Threading.Tasks.Task<ClientManage.BL.SmsService.SendSmsXmlResponse> SendSmsXmlAsync(ClientManage.BL.SmsService.SendSmsXmlRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SendSmsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SendSms", Namespace="http://inforu.co.il/api/v2/asmx/SendMessage/", Order=0)]
        public ClientManage.BL.SmsService.SendSmsRequestBody Body;
        
        public SendSmsRequest() {
        }
        
        public SendSmsRequest(ClientManage.BL.SmsService.SendSmsRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://inforu.co.il/api/v2/asmx/SendMessage/")]
    public partial class SendSmsRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string userName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string apiToken;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string message;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string recipients;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string senderName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string senderNumber;
        
        public SendSmsRequestBody() {
        }
        
        public SendSmsRequestBody(string userName, string apiToken, string message, string recipients, string senderName, string senderNumber) {
            this.userName = userName;
            this.apiToken = apiToken;
            this.message = message;
            this.recipients = recipients;
            this.senderName = senderName;
            this.senderNumber = senderNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SendSmsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SendSmsResponse", Namespace="http://inforu.co.il/api/v2/asmx/SendMessage/", Order=0)]
        public ClientManage.BL.SmsService.SendSmsResponseBody Body;
        
        public SendSmsResponse() {
        }
        
        public SendSmsResponse(ClientManage.BL.SmsService.SendSmsResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://inforu.co.il/api/v2/asmx/SendMessage/")]
    public partial class SendSmsResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string SendSmsResult;
        
        public SendSmsResponseBody() {
        }
        
        public SendSmsResponseBody(string SendSmsResult) {
            this.SendSmsResult = SendSmsResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SendSmsDetailedRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SendSmsDetailed", Namespace="http://inforu.co.il/api/v2/asmx/SendMessage/", Order=0)]
        public ClientManage.BL.SmsService.SendSmsDetailedRequestBody Body;
        
        public SendSmsDetailedRequest() {
        }
        
        public SendSmsDetailedRequest(ClientManage.BL.SmsService.SendSmsDetailedRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://inforu.co.il/api/v2/asmx/SendMessage/")]
    public partial class SendSmsDetailedRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string userName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string apiToken;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string message;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string messagePelephone;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string messageCellcom;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string messageOrange;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string messageMirs;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string recipients;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string customerParameter;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string customerMessageId;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=10)]
        public int messageInterval;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=11)]
        public System.DateTime timeToSend;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string senderName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string senderNumber;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=14)]
        public int maxSegments;
        
        public SendSmsDetailedRequestBody() {
        }
        
        public SendSmsDetailedRequestBody(string userName, string apiToken, string message, string messagePelephone, string messageCellcom, string messageOrange, string messageMirs, string recipients, string customerParameter, string customerMessageId, int messageInterval, System.DateTime timeToSend, string senderName, string senderNumber, int maxSegments) {
            this.userName = userName;
            this.apiToken = apiToken;
            this.message = message;
            this.messagePelephone = messagePelephone;
            this.messageCellcom = messageCellcom;
            this.messageOrange = messageOrange;
            this.messageMirs = messageMirs;
            this.recipients = recipients;
            this.customerParameter = customerParameter;
            this.customerMessageId = customerMessageId;
            this.messageInterval = messageInterval;
            this.timeToSend = timeToSend;
            this.senderName = senderName;
            this.senderNumber = senderNumber;
            this.maxSegments = maxSegments;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SendSmsDetailedResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SendSmsDetailedResponse", Namespace="http://inforu.co.il/api/v2/asmx/SendMessage/", Order=0)]
        public ClientManage.BL.SmsService.SendSmsDetailedResponseBody Body;
        
        public SendSmsDetailedResponse() {
        }
        
        public SendSmsDetailedResponse(ClientManage.BL.SmsService.SendSmsDetailedResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://inforu.co.il/api/v2/asmx/SendMessage/")]
    public partial class SendSmsDetailedResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string SendSmsDetailedResult;
        
        public SendSmsDetailedResponseBody() {
        }
        
        public SendSmsDetailedResponseBody(string SendSmsDetailedResult) {
            this.SendSmsDetailedResult = SendSmsDetailedResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SendSmsXmlRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SendSmsXml", Namespace="http://inforu.co.il/api/v2/asmx/SendMessage/", Order=0)]
        public ClientManage.BL.SmsService.SendSmsXmlRequestBody Body;
        
        public SendSmsXmlRequest() {
        }
        
        public SendSmsXmlRequest(ClientManage.BL.SmsService.SendSmsXmlRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://inforu.co.il/api/v2/asmx/SendMessage/")]
    public partial class SendSmsXmlRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string xmlData;
        
        public SendSmsXmlRequestBody() {
        }
        
        public SendSmsXmlRequestBody(string xmlData) {
            this.xmlData = xmlData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SendSmsXmlResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SendSmsXmlResponse", Namespace="http://inforu.co.il/api/v2/asmx/SendMessage/", Order=0)]
        public ClientManage.BL.SmsService.SendSmsXmlResponseBody Body;
        
        public SendSmsXmlResponse() {
        }
        
        public SendSmsXmlResponse(ClientManage.BL.SmsService.SendSmsXmlResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://inforu.co.il/api/v2/asmx/SendMessage/")]
    public partial class SendSmsXmlResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string SendSmsXmlResult;
        
        public SendSmsXmlResponseBody() {
        }
        
        public SendSmsXmlResponseBody(string SendSmsXmlResult) {
            this.SendSmsXmlResult = SendSmsXmlResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SendMessageSoapChannel : ClientManage.BL.SmsService.SendMessageSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SendMessageSoapClient : System.ServiceModel.ClientBase<ClientManage.BL.SmsService.SendMessageSoap>, ClientManage.BL.SmsService.SendMessageSoap {
        
        public SendMessageSoapClient() {
        }
        
        public SendMessageSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SendMessageSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SendMessageSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SendMessageSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClientManage.BL.SmsService.SendSmsResponse ClientManage.BL.SmsService.SendMessageSoap.SendSms(ClientManage.BL.SmsService.SendSmsRequest request) {
            return base.Channel.SendSms(request);
        }
        
        public string SendSms(string userName, string apiToken, string message, string recipients, string senderName, string senderNumber) {
            ClientManage.BL.SmsService.SendSmsRequest inValue = new ClientManage.BL.SmsService.SendSmsRequest();
            inValue.Body = new ClientManage.BL.SmsService.SendSmsRequestBody();
            inValue.Body.userName = userName;
            inValue.Body.apiToken = apiToken;
            inValue.Body.message = message;
            inValue.Body.recipients = recipients;
            inValue.Body.senderName = senderName;
            inValue.Body.senderNumber = senderNumber;
            ClientManage.BL.SmsService.SendSmsResponse retVal = ((ClientManage.BL.SmsService.SendMessageSoap)(this)).SendSms(inValue);
            return retVal.Body.SendSmsResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ClientManage.BL.SmsService.SendSmsResponse> ClientManage.BL.SmsService.SendMessageSoap.SendSmsAsync(ClientManage.BL.SmsService.SendSmsRequest request) {
            return base.Channel.SendSmsAsync(request);
        }
        
        public System.Threading.Tasks.Task<ClientManage.BL.SmsService.SendSmsResponse> SendSmsAsync(string userName, string apiToken, string message, string recipients, string senderName, string senderNumber) {
            ClientManage.BL.SmsService.SendSmsRequest inValue = new ClientManage.BL.SmsService.SendSmsRequest();
            inValue.Body = new ClientManage.BL.SmsService.SendSmsRequestBody();
            inValue.Body.userName = userName;
            inValue.Body.apiToken = apiToken;
            inValue.Body.message = message;
            inValue.Body.recipients = recipients;
            inValue.Body.senderName = senderName;
            inValue.Body.senderNumber = senderNumber;
            return ((ClientManage.BL.SmsService.SendMessageSoap)(this)).SendSmsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClientManage.BL.SmsService.SendSmsDetailedResponse ClientManage.BL.SmsService.SendMessageSoap.SendSmsDetailed(ClientManage.BL.SmsService.SendSmsDetailedRequest request) {
            return base.Channel.SendSmsDetailed(request);
        }
        
        public string SendSmsDetailed(string userName, string apiToken, string message, string messagePelephone, string messageCellcom, string messageOrange, string messageMirs, string recipients, string customerParameter, string customerMessageId, int messageInterval, System.DateTime timeToSend, string senderName, string senderNumber, int maxSegments) {
            ClientManage.BL.SmsService.SendSmsDetailedRequest inValue = new ClientManage.BL.SmsService.SendSmsDetailedRequest();
            inValue.Body = new ClientManage.BL.SmsService.SendSmsDetailedRequestBody();
            inValue.Body.userName = userName;
            inValue.Body.apiToken = apiToken;
            inValue.Body.message = message;
            inValue.Body.messagePelephone = messagePelephone;
            inValue.Body.messageCellcom = messageCellcom;
            inValue.Body.messageOrange = messageOrange;
            inValue.Body.messageMirs = messageMirs;
            inValue.Body.recipients = recipients;
            inValue.Body.customerParameter = customerParameter;
            inValue.Body.customerMessageId = customerMessageId;
            inValue.Body.messageInterval = messageInterval;
            inValue.Body.timeToSend = timeToSend;
            inValue.Body.senderName = senderName;
            inValue.Body.senderNumber = senderNumber;
            inValue.Body.maxSegments = maxSegments;
            ClientManage.BL.SmsService.SendSmsDetailedResponse retVal = ((ClientManage.BL.SmsService.SendMessageSoap)(this)).SendSmsDetailed(inValue);
            return retVal.Body.SendSmsDetailedResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ClientManage.BL.SmsService.SendSmsDetailedResponse> ClientManage.BL.SmsService.SendMessageSoap.SendSmsDetailedAsync(ClientManage.BL.SmsService.SendSmsDetailedRequest request) {
            return base.Channel.SendSmsDetailedAsync(request);
        }
        
        public System.Threading.Tasks.Task<ClientManage.BL.SmsService.SendSmsDetailedResponse> SendSmsDetailedAsync(string userName, string apiToken, string message, string messagePelephone, string messageCellcom, string messageOrange, string messageMirs, string recipients, string customerParameter, string customerMessageId, int messageInterval, System.DateTime timeToSend, string senderName, string senderNumber, int maxSegments) {
            ClientManage.BL.SmsService.SendSmsDetailedRequest inValue = new ClientManage.BL.SmsService.SendSmsDetailedRequest();
            inValue.Body = new ClientManage.BL.SmsService.SendSmsDetailedRequestBody();
            inValue.Body.userName = userName;
            inValue.Body.apiToken = apiToken;
            inValue.Body.message = message;
            inValue.Body.messagePelephone = messagePelephone;
            inValue.Body.messageCellcom = messageCellcom;
            inValue.Body.messageOrange = messageOrange;
            inValue.Body.messageMirs = messageMirs;
            inValue.Body.recipients = recipients;
            inValue.Body.customerParameter = customerParameter;
            inValue.Body.customerMessageId = customerMessageId;
            inValue.Body.messageInterval = messageInterval;
            inValue.Body.timeToSend = timeToSend;
            inValue.Body.senderName = senderName;
            inValue.Body.senderNumber = senderNumber;
            inValue.Body.maxSegments = maxSegments;
            return ((ClientManage.BL.SmsService.SendMessageSoap)(this)).SendSmsDetailedAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClientManage.BL.SmsService.SendSmsXmlResponse ClientManage.BL.SmsService.SendMessageSoap.SendSmsXml(ClientManage.BL.SmsService.SendSmsXmlRequest request) {
            return base.Channel.SendSmsXml(request);
        }
        
        public string SendSmsXml(string xmlData) {
            ClientManage.BL.SmsService.SendSmsXmlRequest inValue = new ClientManage.BL.SmsService.SendSmsXmlRequest();
            inValue.Body = new ClientManage.BL.SmsService.SendSmsXmlRequestBody();
            inValue.Body.xmlData = xmlData;
            ClientManage.BL.SmsService.SendSmsXmlResponse retVal = ((ClientManage.BL.SmsService.SendMessageSoap)(this)).SendSmsXml(inValue);
            return retVal.Body.SendSmsXmlResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ClientManage.BL.SmsService.SendSmsXmlResponse> ClientManage.BL.SmsService.SendMessageSoap.SendSmsXmlAsync(ClientManage.BL.SmsService.SendSmsXmlRequest request) {
            return base.Channel.SendSmsXmlAsync(request);
        }
        
        public System.Threading.Tasks.Task<ClientManage.BL.SmsService.SendSmsXmlResponse> SendSmsXmlAsync(string xmlData) {
            ClientManage.BL.SmsService.SendSmsXmlRequest inValue = new ClientManage.BL.SmsService.SendSmsXmlRequest();
            inValue.Body = new ClientManage.BL.SmsService.SendSmsXmlRequestBody();
            inValue.Body.xmlData = xmlData;
            return ((ClientManage.BL.SmsService.SendMessageSoap)(this)).SendSmsXmlAsync(inValue);
        }
    }
}
