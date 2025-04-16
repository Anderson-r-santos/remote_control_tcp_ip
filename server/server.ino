#include <ESP8266WiFi.h>
#include <Servo.h>

#define pinAccel 2
#define pinBack 0
#define servoDir 3

#define networkName ""  //definir nome da rede wifi
#define networkPassword ""  //definir senha da rede wifi

WiFiServer server(9001); //mudar a porta,se nescessario
Servo servoDirection;

int currentAngle = 90;
byte buffer[4];

void setup() {


  pinMode(pinBack,OUTPUT);
  pinMode(pinAccel,OUTPUT);

  servoDirection.attach(servoDir);

  Serial.begin(9600);
  
  Serial.print("servidor tentando conectar");
  WiFi.begin(networkName,networkPassword);

  while(WiFi.status() != WL_CONNECTED)
  {
    delay(500);
    Serial.print(".");
  }
  Serial.println("\n servidor conectado ao roteador com sucesso!");
  String ipPrint = "endereço de IP : " + WiFi.localIP().toString();
  Serial.println(ipPrint);


  server.begin();
  Serial.println("servidor iniciado");
  Serial.end(); //se precisar de debug,comentar essa linha,pois precisamos do pino que para o servo,porem o esp 01 usa ele para o serial
  setInitState();
}

void setInitState()
{
  pinMode(servoDir,OUTPUT);
 
  digitalWrite(pinAccel,HIGH);
  digitalWrite(pinBack,HIGH);//precisa esta em high para nao entrar em modo gravaçao
  digitalWrite(servoDir,LOW);

}

void loop() {
 
  WiFiClient client = server.available();

  if(client)
  {
    Serial.println("cliente conectado!");
   
  }

  while(client.connected())
  {
    if(client.available()){
        int lenght = client.read(buffer,sizeof(buffer));
        if(lenght > 0)
        {

          checkActionClient();

        }
    }
  }

  client.stop();
}

void checkActionClient()
{
 

  char left = char(buffer[0]); 
  char right = char(buffer[1]);
  char brake = char(buffer[2]);
  char accel = char(buffer[3]);

  Serial.print(".");
  accelerate(accel);
  back(brake);
  changeDirection(left,right);

}


void changeDirection(char left,char right)
{
  if(left == '1')
  {

    currentAngle = constrain(currentAngle - 50, 0, 180);
    Serial.println("virando para a esquerda. " + String(currentAngle));
  }else if(right == '1')
  {

    currentAngle = constrain(currentAngle + 50, 0, 180);
    Serial.println("virando para a direita. " + String(currentAngle));
  }else 
  {

    currentAngle = 90;
   
  }
   servoDirection.write(currentAngle);
   
}
void accelerate(char status)
{
  if(status == '1')
  {
    Serial.println("acelerando!!");
    digitalWrite(pinAccel,1);
    digitalWrite(pinBack,0);
  }
  else{
    digitalWrite(pinAccel,0);

  }
}


void back(char status)
{
  if(status == '1')
  {
    Serial.println("brecando!!");
    digitalWrite(pinBack,1);
    digitalWrite(pinAccel,0);
  }else{
    digitalWrite(pinBack,0);

  }
}

