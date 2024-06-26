﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReportManager.ReportServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReportServiceReference.IReportService", CallbackContract=typeof(ReportManager.ReportServiceReference.IReportServiceCallback))]
    public interface IReportService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportService/GetAlarmsByPeriod", ReplyAction="http://tempuri.org/IReportService/GetAlarmsByPeriodResponse")]
        CommonLibrary.Model.ActivatedAlarm[] GetAlarmsByPeriod(System.DateTime startTime, System.DateTime endTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportService/GetAlarmsByPeriod", ReplyAction="http://tempuri.org/IReportService/GetAlarmsByPeriodResponse")]
        System.Threading.Tasks.Task<CommonLibrary.Model.ActivatedAlarm[]> GetAlarmsByPeriodAsync(System.DateTime startTime, System.DateTime endTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportService/GetAlarmsByPriority", ReplyAction="http://tempuri.org/IReportService/GetAlarmsByPriorityResponse")]
        CommonLibrary.Model.ActivatedAlarm[] GetAlarmsByPriority(int priority);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportService/GetAlarmsByPriority", ReplyAction="http://tempuri.org/IReportService/GetAlarmsByPriorityResponse")]
        System.Threading.Tasks.Task<CommonLibrary.Model.ActivatedAlarm[]> GetAlarmsByPriorityAsync(int priority);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportService/GetTagValuesByPeriod", ReplyAction="http://tempuri.org/IReportService/GetTagValuesByPeriodResponse")]
        CommonLibrary.Model.TagEntity[] GetTagValuesByPeriod(System.DateTime startTime, System.DateTime endTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportService/GetTagValuesByPeriod", ReplyAction="http://tempuri.org/IReportService/GetTagValuesByPeriodResponse")]
        System.Threading.Tasks.Task<CommonLibrary.Model.TagEntity[]> GetTagValuesByPeriodAsync(System.DateTime startTime, System.DateTime endTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportService/GetLastAITagValues", ReplyAction="http://tempuri.org/IReportService/GetLastAITagValuesResponse")]
        CommonLibrary.Model.TagEntity[] GetLastAITagValues();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportService/GetLastAITagValues", ReplyAction="http://tempuri.org/IReportService/GetLastAITagValuesResponse")]
        System.Threading.Tasks.Task<CommonLibrary.Model.TagEntity[]> GetLastAITagValuesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportService/GetLastDITagValues", ReplyAction="http://tempuri.org/IReportService/GetLastDITagValuesResponse")]
        CommonLibrary.Model.TagEntity[] GetLastDITagValues();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportService/GetLastDITagValues", ReplyAction="http://tempuri.org/IReportService/GetLastDITagValuesResponse")]
        System.Threading.Tasks.Task<CommonLibrary.Model.TagEntity[]> GetLastDITagValuesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportService/GetTagValuesByName", ReplyAction="http://tempuri.org/IReportService/GetTagValuesByNameResponse")]
        CommonLibrary.Model.TagEntity[] GetTagValuesByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportService/GetTagValuesByName", ReplyAction="http://tempuri.org/IReportService/GetTagValuesByNameResponse")]
        System.Threading.Tasks.Task<CommonLibrary.Model.TagEntity[]> GetTagValuesByNameAsync(string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReportServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IReportService/MessageArrived")]
        void MessageArrived(string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReportServiceChannel : ReportManager.ReportServiceReference.IReportService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReportServiceClient : System.ServiceModel.DuplexClientBase<ReportManager.ReportServiceReference.IReportService>, ReportManager.ReportServiceReference.IReportService {
        
        public ReportServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ReportServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ReportServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ReportServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ReportServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public CommonLibrary.Model.ActivatedAlarm[] GetAlarmsByPeriod(System.DateTime startTime, System.DateTime endTime) {
            return base.Channel.GetAlarmsByPeriod(startTime, endTime);
        }
        
        public System.Threading.Tasks.Task<CommonLibrary.Model.ActivatedAlarm[]> GetAlarmsByPeriodAsync(System.DateTime startTime, System.DateTime endTime) {
            return base.Channel.GetAlarmsByPeriodAsync(startTime, endTime);
        }
        
        public CommonLibrary.Model.ActivatedAlarm[] GetAlarmsByPriority(int priority) {
            return base.Channel.GetAlarmsByPriority(priority);
        }
        
        public System.Threading.Tasks.Task<CommonLibrary.Model.ActivatedAlarm[]> GetAlarmsByPriorityAsync(int priority) {
            return base.Channel.GetAlarmsByPriorityAsync(priority);
        }
        
        public CommonLibrary.Model.TagEntity[] GetTagValuesByPeriod(System.DateTime startTime, System.DateTime endTime) {
            return base.Channel.GetTagValuesByPeriod(startTime, endTime);
        }
        
        public System.Threading.Tasks.Task<CommonLibrary.Model.TagEntity[]> GetTagValuesByPeriodAsync(System.DateTime startTime, System.DateTime endTime) {
            return base.Channel.GetTagValuesByPeriodAsync(startTime, endTime);
        }
        
        public CommonLibrary.Model.TagEntity[] GetLastAITagValues() {
            return base.Channel.GetLastAITagValues();
        }
        
        public System.Threading.Tasks.Task<CommonLibrary.Model.TagEntity[]> GetLastAITagValuesAsync() {
            return base.Channel.GetLastAITagValuesAsync();
        }
        
        public CommonLibrary.Model.TagEntity[] GetLastDITagValues() {
            return base.Channel.GetLastDITagValues();
        }
        
        public System.Threading.Tasks.Task<CommonLibrary.Model.TagEntity[]> GetLastDITagValuesAsync() {
            return base.Channel.GetLastDITagValuesAsync();
        }
        
        public CommonLibrary.Model.TagEntity[] GetTagValuesByName(string name) {
            return base.Channel.GetTagValuesByName(name);
        }
        
        public System.Threading.Tasks.Task<CommonLibrary.Model.TagEntity[]> GetTagValuesByNameAsync(string name) {
            return base.Channel.GetTagValuesByNameAsync(name);
        }
    }
}
