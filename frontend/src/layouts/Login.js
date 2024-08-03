import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios';
import gloves from "../assets/img/gloves.png";
import "../assets/css/login.css";

function Login() {
  const navigate = useNavigate();

  useEffect(() => {
    if (localStorage.getItem('punch-vison-user')) {
      navigate("/");
    }
  }, [])


  const handleSubmit = async (e) => {
    e.preventDefault();
    const formData = new FormData(e.target);
    const obj = {
      username: formData.get("username") ?? "",
      password: formData.get("password") ?? "",
    };
    if (handleValidation(obj)) {
      navigate("/admin/mainView")

      // const { password, username } = obj;
      // const { data } = await axios.post(loginRoute, {
      //   username,
      //   password
      // });
      // if (data.status === false)
      //   alert(data.message)
      // if (data.status === true) {
      //   localStorage.setItem('punch-vison-user', JSON.stringify(data.user))
      //   navigate("/");
      // }
    }
  }

  const handleValidation = (obj) => {
    const { password, username } = obj
    if (password.length === ("" || 0)) {
      alert(
        "Nome e senha são obrigatórios."
      );
      return false
    } else if (username.length === ("" || 0)) {
      alert(
        "Nome e senha são obrigatórios."
      );
      return false
    }
    return true;
  }


  return (
    <>
      <div className='login-content'>
        <div className='login'>
          <div className='title'>
            <h1>Entre na sua Conta</h1>
          </div>
          <hr />
          <form onSubmit={handleSubmit} className='form-custom'>
            <div className='col-md-8'>
              <input placeholder="Usuário" name="username" className='form-control custom-input' type='text' aria-label="Usuário" />
              <input placeholder="Senha" name="password" className='form-control custom-input' type='password' aria-label="Senha" />
            </div>
            <span className='login-span'>esqueceu a senha?</span>
            <button type="submit" className="btn btn-primary login-button">Submit</button>
          </form>
        </div>
        <div className='register-content'>
          <div className='register'>
            <h1>Novo Aqui?</h1>
            <span className='register-span'>Crie sua conta e descubra todas funcionalidades dessa ferramenta</span>
            <Link to="/cadastro">
              <button className="btn btn-primary register-button">Cadastrar</button>
            </Link>
            <div>
              <img src={gloves} alt='blue glove' className='custom-img' />
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default Login;
