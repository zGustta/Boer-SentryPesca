var btnSignin = document.querySelector("#signin");
var btnSignup = document.querySelector("#signup");
var body = document.querySelector("body");

btnSignin.addEventListener("click", function () {
  body.className = "sign-in-js";
});

btnSignup.addEventListener("click", function () {
  body.className = "sign-up-js";
  var passwordInput = document.querySelector("#password");
  var password = passwordInput.value;

  if (!isValidPassword(password)) {
    alert("A senha deve ter de 8 a 16 caracteres, incluindo pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.");
  } else {
    // Salvar senha no localStorage
    localStorage.setItem("userPassword", password);
    alert("Cadastro realizado com sucesso!");
    // Você pode redirecionar ou executar outras ações após o cadastro
  }
});

function isValidPassword(password) {
  // Expressão regular para verificar se a senha atende aos critérios especificados
  var passwordPattern = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,16}$/;
  return passwordPattern.test(password);
}

// Função para realizar o login
function login() {
  var emailInput = document.querySelector("#emailLogin");
  var senhaInput = document.querySelector("#senhaLogin");
  var email = emailInput.value;
  var senha = senhaInput.value;
  
  // Recuperar a senha cadastrada do localStorage
  var senhaArmazenada = localStorage.getItem("userPassword");

  if (!senhaArmazenada || senhaArmazenada !== senha) {
    alert("E-mail ou senha incorretos.");
  } else {
    alert("Login bem-sucedido!");
    window.location.href = 'index.html';  // Redirecionar para a página de destino
  }
}

// Adicionar a função de login ao formulário de login
var loginForm = document.getElementById("loginForm");
loginForm.addEventListener("submit", function (event) {
  event.preventDefault();
  login();
});