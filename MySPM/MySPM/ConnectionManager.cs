using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySPM
{
  public sealed class ConnectionManager
  {
    private static DynamoDBContext _context;

    public static DynamoDBContext Context
    {
      get { return _context; }
    }

    public static void StartConnection()
    {
      var logginConfig = AWSConfigs.LoggingConfig;
      logginConfig.LogMetrics = true;
      logginConfig.LogResponses = ResponseLoggingOption.Always;
      logginConfig.LogMetricsFormat = LogMetricsFormatOption.JSON;
      logginConfig.LogTo = LoggingOptions.SystemDiagnostics;

      AWSConfigs.AWSRegion = "us-east-2";

      CognitoAWSCredentials credenciales = new CognitoAWSCredentials("us-east-2:e7065761-1f89-45be-958e-accf1a15ee1b", RegionEndpoint.USEast2);

      var client = new AmazonDynamoDBClient(credenciales, RegionEndpoint.USEast2);

      _context = new DynamoDBContext(client);
    }
  }
}
