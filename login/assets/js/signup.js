let btn = document.querySelector('#verSenha')
let btnConfirm = document.querySelector('#verConfirmSenha')


let nome = document.querySelector('#nome')
let labelNome = document.querySelector('#labelNome')
let validNome = false

let usuario = document.querySelector('#usuario')
let labelUsuario = document.querySelector('#labelUsuario')
let validUsuario = false

let senha = document.querySelector('#senha')
let labelSenha = document.querySelector('#labelSenha')
let validSenha = false

let confirmSenha = document.querySelector('#confirmSenha')
let labelConfirmSenha = document.querySelector('#labelConfirmSenha')
let validConfirmSenha = false

let msgError = document.querySelector('#msgError')
let msgSuccess = document.querySelector('#msgSuccess')



nome.addEventListener('keyup', () => {
  if(nome.value.length <= 2){
    labelNome.setAttribute('style', 'color: red')
    labelNome.innerHTML = 'Nome *Insira no minimo 3 caracteres'
    nome.setAttribute('style', 'border-color: red')
    validNome = false
  } else if (!nome.value.includes('@') || !nome.value.includes('.')) {
    labelNome.setAttribute('style', 'color: red')
    labelNome.innerHTML = 'e-mail *Insira um endereço de e-mail válido'
    nome.setAttribute('style', 'border-color: red')
    validNome = false
  } else {
    labelNome.setAttribute('style', 'color: green')
    labelNome.innerHTML = 'Nome'
    nome.setAttribute('style', 'border-color: green')
    validNome = true
  }
})

usuario.addEventListener('keyup', () => {
  if(usuario.value.length <= 4){
    labelUsuario.setAttribute('style', 'color: red')
    labelUsuario.innerHTML = 'Usuário *Insira no minimo 5 caracteres'
    usuario.setAttribute('style', 'border-color: red')
    validUsuario = false
  } else {
    labelUsuario.setAttribute('style', 'color: green')
    labelUsuario.innerHTML = 'Usuário'
    usuario.setAttribute('style', 'border-color: green')
    validUsuario = true
  }
})

senha.addEventListener('keyup', () => {
  let senhaValue = senha.value;
  let hasNumber = /\d/.test(senhaValue);
  let hasLetter = /[a-zA-Z]/.test(senhaValue);
  let hasSpecialChar = /[!@#$%^&*(),.?":{}|<>]/.test(senhaValue);

  if (senhaValue.length <= 5 || !hasNumber || !hasLetter || !hasSpecialChar) {
    labelSenha.setAttribute('style', 'color: red');
    labelSenha.innerHTML = 'Senha *Insira no mínimo 6 caracteres, incluindo pelo menos 1 número, 1 letra e 1 caractere especial';
    senha.setAttribute('style', 'border-color: red');
    validSenha = false;
  } else {
    labelSenha.setAttribute('style', 'color: green');
    labelSenha.innerHTML = 'Senha';
    senha.setAttribute('style', 'border-color: green');
    validSenha = true;
  }
});


confirmSenha.addEventListener('keyup', () => {
  if(senha.value != confirmSenha.value){
    labelConfirmSenha.setAttribute('style', 'color: red')
    labelConfirmSenha.innerHTML = 'Confirmar Senha *As senhas não conferem'
    confirmSenha.setAttribute('style', 'border-color: red')
    validConfirmSenha = false
  } else {
    labelConfirmSenha.setAttribute('style', 'color: green')
    labelConfirmSenha.innerHTML = 'Confirmar Senha'
    confirmSenha.setAttribute('style', 'border-color: green')
    validConfirmSenha = true
  }
})

function cadastrar() {
  // Verifica se todos os campos estão preenchidos corretamente
  if (validNome && validUsuario && validSenha && validConfirmSenha) {
    // Verifica se o checkbox dos termos está marcado
    if (!document.querySelector('#termos').checked) {
      alert("Você precisa concordar com os termos antes de prosseguir.");
      return; // Para a execução da função se os termos não forem aceitos
    }
    
    // Se todos os campos estiverem preenchidos corretamente e os termos foram aceitos
    let listaUser = JSON.parse(localStorage.getItem('listaUser') || '[]');
    
    listaUser.push({
      nomeCad: nome.value,
      userCad: usuario.value,
      senhaCad: senha.value
    });
    
    localStorage.setItem('listaUser', JSON.stringify(listaUser));
    
    msgSuccess.setAttribute('style', 'display: block');
    msgSuccess.innerHTML = '<strong>Cadastrando usuário...</strong>';
    msgError.setAttribute('style', 'display: none');
    msgError.innerHTML = '';
    
    setTimeout(() => {
      window.location.href = '../html/signin.html';
    }, 3000);
  } else {
    msgError.setAttribute('style', 'display: block');
    msgError.innerHTML = '<strong>Preencha todos os campos corretamente antes de cadastrar</strong>';
    msgSuccess.innerHTML = '';
    msgSuccess.setAttribute('style', 'display: none');
  }
}




  
  
