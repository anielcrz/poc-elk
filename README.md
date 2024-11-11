1° Para executar baixe o projeto do seguinte link: [https://github.com/anielcrz/docker-elk](https://github.com/anielcrz/docker-elk)

2° Com o ambiente do Docker já configurado rode os comandos  em seguida em um terminal em modo administrador:

```
docker compose up setup
docker compose up
```

3° Em execução, para que o logstash capture corretamente o log da POC é preciso configurar a segurança de captura, para isso acesse o kibana com o usuário: elastic e senha: changeme

4° Em seguida crie ou edite uma Role onde você definirá o nome e as permissões do índice da aplicação, usando o nome ou parte dele, acessando: http://localhost:5601/app/management/security/roles/
 ![image](https://github.com/user-attachments/assets/69b67270-124e-4f55-a848-07ed13f15bae)

Em nosso exemplo foi criada a Interplayers_logstash

 ![image](https://github.com/user-attachments/assets/cf88476c-8d5f-4be8-9ea2-e2eb30a45f84)

5° Na seção de Index privileges defina o nome ou a raiz dos índices (no nosso exemplo o índice log*) com os seguintes privilégios: auto_configure, all, create_index e manage.
 ![image](https://github.com/user-attachments/assets/78d6c1ee-91e3-4747-ba14-c68d3f71ca8d)

6° No setor de usuários (http://localhost:5601/app/management/security/users) associe a role para o usuário configurado para o Logstash, no nosso exemplo o logstash_internal.
 ![image](https://github.com/user-attachments/assets/7db0b3d5-bb9e-4848-9004-d478c396d6b1)

7° Também garanta que o usuário possua a mesma senha configurada no logstash, usando o “Change password”:
![image](https://github.com/user-attachments/assets/3b20eb8f-eb9f-447a-8c67-ecb27c973196)
_Tela de alteração de senha
_
 ![image](https://github.com/user-attachments/assets/b3274ef0-eaae-44f6-9938-c14eaa089ff4)
_Dados de configuração do logstash._

8° Após a execução da aplicação acesse o kibana Discover e configure a visualização de acordo com o índice:
 ![image](https://github.com/user-attachments/assets/30eef0ee-3bbe-4bfa-b2f6-204ad2bcd28a)



