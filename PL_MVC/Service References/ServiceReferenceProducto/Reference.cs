//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL_MVC.ServiceReferenceProducto {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceProducto.IServiceProducto")]
    public interface IServiceProducto {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceProducto/Add", ReplyAction="http://tempuri.org/IServiceProducto/AddResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(SL_WCF.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Proveedor))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Producto))]
        SL_WCF.Result Add(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceProducto/Add", ReplyAction="http://tempuri.org/IServiceProducto/AddResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> AddAsync(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceProducto/Update", ReplyAction="http://tempuri.org/IServiceProducto/UpdateResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(SL_WCF.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Proveedor))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Producto))]
        SL_WCF.Result Update(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceProducto/Update", ReplyAction="http://tempuri.org/IServiceProducto/UpdateResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> UpdateAsync(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceProducto/Delete", ReplyAction="http://tempuri.org/IServiceProducto/DeleteResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(SL_WCF.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Proveedor))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Producto))]
        SL_WCF.Result Delete(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceProducto/Delete", ReplyAction="http://tempuri.org/IServiceProducto/DeleteResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> DeleteAsync(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceProducto/GetAll", ReplyAction="http://tempuri.org/IServiceProducto/GetAllResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(SL_WCF.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Proveedor))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Producto))]
        SL_WCF.Result GetAll(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceProducto/GetAll", ReplyAction="http://tempuri.org/IServiceProducto/GetAllResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> GetAllAsync(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceProducto/GetById", ReplyAction="http://tempuri.org/IServiceProducto/GetByIdResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(SL_WCF.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Proveedor))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Producto))]
        SL_WCF.Result GetById(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceProducto/GetById", ReplyAction="http://tempuri.org/IServiceProducto/GetByIdResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> GetByIdAsync(ML.Producto producto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceProductoChannel : PL_MVC.ServiceReferenceProducto.IServiceProducto, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceProductoClient : System.ServiceModel.ClientBase<PL_MVC.ServiceReferenceProducto.IServiceProducto>, PL_MVC.ServiceReferenceProducto.IServiceProducto {
        
        public ServiceProductoClient() {
        }
        
        public ServiceProductoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceProductoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceProductoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceProductoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SL_WCF.Result Add(ML.Producto producto) {
            return base.Channel.Add(producto);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> AddAsync(ML.Producto producto) {
            return base.Channel.AddAsync(producto);
        }
        
        public SL_WCF.Result Update(ML.Producto producto) {
            return base.Channel.Update(producto);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> UpdateAsync(ML.Producto producto) {
            return base.Channel.UpdateAsync(producto);
        }
        
        public SL_WCF.Result Delete(ML.Producto producto) {
            return base.Channel.Delete(producto);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> DeleteAsync(ML.Producto producto) {
            return base.Channel.DeleteAsync(producto);
        }
        
        public SL_WCF.Result GetAll(ML.Producto producto) {
            return base.Channel.GetAll(producto);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> GetAllAsync(ML.Producto producto) {
            return base.Channel.GetAllAsync(producto);
        }
        
        public SL_WCF.Result GetById(ML.Producto producto) {
            return base.Channel.GetById(producto);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> GetByIdAsync(ML.Producto producto) {
            return base.Channel.GetByIdAsync(producto);
        }
    }
}
