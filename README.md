Um controle remoto utilizando o celular para controlar um carrinho usando tcp/ip.O esp01 é o Server, e o celular é o cliente. O cliente pode ser refeito de outra forma,foi utilizado a godot engine apenas  para criação de efeitos visual e por familiaridade.

voce terá que descobrir o ip do seu esp01,escolher uma Port,e colocar no server.ini, e se for utilizar o client da godot,colocar o ip e porta do esp que voce descobriu anteriomente no script Client_mobile.

Se você for gerar outro apk na godot,provavelmente vai ter que gerar uma key(na godot 4.4 ou anterior),utilize o android studio para isso.Apos gerada vá na godot, em Project->export->selecione um presets->keystore->release e coloque a chave gerada,atribua o release user,e a release Password,é nescessario o acesso do apk a internet tambem,entao va até permissions e habilite "internet" e pode exportar.
