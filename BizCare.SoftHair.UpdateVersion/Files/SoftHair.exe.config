<configuration>
  <configSections>
    <section name="dataConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Data.Configuration.DatabaseSettings, Microsoft.Practices.EnterpriseLibrary.Data, Version=3.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"/>
  </configSections>
  <dataConfiguration defaultDatabase="SoftHairAppConnStr"/>
  <connectionStrings>
    <add name="SoftHairAppConnStr" connectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Persist Security Info=True; Jet OLEDB:Database Password=37614463;" providerName="System.Data.OleDb"/>
  </connectionStrings>
  <runtime>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="BizCare.WebCam" publicKeyToken="6E3DB4DF2D519524" culture="neutral"/>
        <bindingRedirect oldVersion="0.0.0.0-3.5.2.4" newVersion="3.5.2.4"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="BizCare.WebCam" publicKeyToken="794729DFCAE8AD67" culture="neutral"/>
        <bindingRedirect oldVersion="0.0.0.0-3.7.0.0" newVersion="3.7.0.0"/>
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
  <configProtectedData>
    <providers>
      <add useMachineProtection="true" name="DPAPIProtection" type="System.Configuration.DpapiProtectedConfigurationProvider, System.Configuration, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"/>
    </providers>
  </configProtectedData>
  <system.serviceModel>
    <bindings>
      <basicHttpBinding>
        <binding name="BasicHttpBinding_ISmsService" maxReceivedMessageSize="1048576">
          <readerQuotas maxDepth="32" maxStringContentLength="524288" maxArrayLength="16384"
            maxBytesPerRead="4096" maxNameTableCharCount="16384" />
          <security mode="None" />
        </binding>
        <binding name="BasicHttpBinding_ICommonServices" closeTimeout="00:01:00"
          openTimeout="00:01:00" receiveTimeout="00:10:00" sendTimeout="00:01:00"
          allowCookies="false" bypassProxyOnLocal="false" hostNameComparisonMode="StrongWildcard"
          maxBufferSize="65536" maxBufferPoolSize="524288" maxReceivedMessageSize="65536"
          messageEncoding="Text" textEncoding="utf-8" transferMode="Buffered"
          useDefaultWebProxy="true">
          <readerQuotas maxDepth="32" maxStringContentLength="8192" maxArrayLength="16384"
            maxBytesPerRead="4096" maxNameTableCharCount="16384" />
          <security mode="None">
            <transport clientCredentialType="None" proxyCredentialType="None"
              realm="" />
            <message clientCredentialType="UserName" algorithmSuite="Default" />
          </security>
        </binding>
        <binding name="BasicHttpBinding_ICommonServices1" closeTimeout="00:01:00"
          openTimeout="00:01:00" receiveTimeout="00:10:00" sendTimeout="00:01:00"
          allowCookies="false" bypassProxyOnLocal="false" hostNameComparisonMode="StrongWildcard"
          maxBufferSize="65536" maxBufferPoolSize="524288" maxReceivedMessageSize="65536"
          messageEncoding="Text" textEncoding="utf-8" transferMode="Buffered"
          useDefaultWebProxy="true">
          <readerQuotas maxDepth="32" maxStringContentLength="8192" maxArrayLength="16384"
            maxBytesPerRead="4096" maxNameTableCharCount="16384" />
          <security mode="None">
            <transport clientCredentialType="None" proxyCredentialType="None"
              realm="" />
            <message clientCredentialType="UserName" algorithmSuite="Default" />
          </security>
        </binding>
      </basicHttpBinding>
    </bindings>
    <client>
      <endpoint address="" binding="basicHttpBinding" bindingConfiguration="BasicHttpBinding_ISmsService"
        contract="SmsFactoryService.ISmsService" name="BasicHttpBinding_ISmsService" />
      <endpoint address="" binding="basicHttpBinding" bindingConfiguration="BasicHttpBinding_ICommonServices"
        contract="SmsFactoryCommon.ICommonServices" name="BasicHttpBinding_ICommonServices" />
      <endpoint address="http://localhost:6945/Services/CommonServices.svc"
        binding="basicHttpBinding" bindingConfiguration="BasicHttpBinding_ICommonServices1"
        contract="SmsFactoryCommon.ICommonServices" name="BasicHttpBinding_ICommonServices1" />
    </client>
  </system.serviceModel>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0"/>
  </startup>
  <system.net>
    <settings>
      <httpWebRequest useUnsafeHeaderParsing="true"  />
    </settings>
  </system.net>
  <system.diagnostics>
    <trace autoflush="true" indentsize="4">
      <listeners>
        <add name="myListener" type="System.Diagnostics.TextWriterTraceListener" initializeData="TraceOutput.log" />
        <remove name="Default" />
      </listeners>
    </trace>
  </system.diagnostics>
</configuration>
