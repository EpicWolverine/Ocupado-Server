#include <Arduino.h> //does something
#include <ESP8266WiFi.h> //does something wifi related withteh board
#include <ESP8266WiFiMulti.h> //multi - threaded wifi
#include <ESP8266HTTPClient.h> //Clients, now with delicious HTTP
#include <ArduinoJson.h> //Json is hard to implement. Dont be like Json
#include <Ethernet.h>
ESP8266WiFiMulti WiFiMulti; //Does something.
WiFiClient client;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  Serial.println();
  WiFi.begin("MHacksGuest", "mhackshype");
  pinMode(5, INPUT);
}
bool OCC = false;

void loop() {

  HTTPClient http;
  http.begin("http://ocupado.azurewebsites.net/api/SensorUpdate/StallStatus");
  if (digitalRead(5))
  {
    OCC = !OCC;
    delay(1000);
    if (OCC)
    {
      
      http.begin("http://ocupado.azurewebsites.net/api/SensorUpdate/StallStatusGet?id=1&occupied=true");
      int httpCode = http.GET();
      Serial.println("Occupied");
      if(httpCode == HTTP_CODE_OK) {
                String payload = http.getString();
                Serial.println(payload);}
      
    }
    else
    {
      
      Serial.println("Free");
      http.begin("http://ocupado.azurewebsites.net/api/SensorUpdate/StallStatusGet?id=1&occupied=false");
      int httpCode = http.GET();
      if(httpCode == HTTP_CODE_OK) {
                String payload = http.getString();
                Serial.println(payload);}
    }
  }

  //

  //senddata(root);
  //   http.sendRequest("POST", jsonString);
  //  int httpCode = http.POST(jsonString);
  //  String payload = http.getString();
  //  http.end();
  //  // put your main code here, to run repeatedly:
  
}

//Example POST to Azure

void senddata(JsonObject& json)
{
  // POST URI
  client.print("PUT http://ocupado.azurewebsites.net/api/SensorUpdate/StallStatus"); client.println(" HTTP/1.1");
  //// Host header
  client.print("Host:"); client.println("ocupado.azurewebsites.net");
  //// Azure Mobile Services application key
 // client.print("X-ZUMO-APPLICATION:"); client.println(ams_key);
  //// JSON content type
  client.println("Accept: application/json");
  client.println("Content-Type: application/json");
  //// Content length
  int length = json.measureLength();
  client.print("Content-Length:"); client.println(length);
  //// End of headers
  client.println();
  //// POST message body
  json.printTo(client); // very slow ??
  String out;
  json.printTo(out);
  client.println(out);
}
