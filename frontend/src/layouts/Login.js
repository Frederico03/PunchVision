import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useForm } from "react-hook-form";
import axios from 'axios';
import gloves from "../assets/img/gloves.png";
import { loginRoute } from 'API/api';
import "../assets/css/login.css";

function Login() {
  const navigate = useNavigate();

  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm();

  useEffect(() => {
    if (localStorage.getItem('punch-vison-user')) {
      navigate("/login");
    }
  }, [])


  const onSubmit = async (req) => {
    if (handleValidation(req)) {
      const { password, email } = req
      const { data } = await axios.post(loginRoute, {
        email,
        password
      });
      console.log(data)
      if (data.status === false)
        alert(data.message)
      if (data.status === true) {
        console.log(data)
        localStorage.setItem('punch-vison-user', JSON.stringify(data.userId))
        localStorage.setItem('punch-vison-token', JSON.stringify(data.token))
        navigate("/admin/mainView")
      }
    }
  }

  const handleValidation = (req) => {
    const { password, email } = req
    if (password.length === ("" || 0)) {
      alert(
        "Email e senha são obrigatórios."
      );
      return false
    } else if (email.length === ("" || 0)) {
      alert(
        "Email e senha são obrigatórios."
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
          <form onSubmit={handleSubmit(onSubmit)} className='form-custom'>
            <div>
              <input
                placeholder="Email"
                className='form-control custom-input'
                type='email'
                aria-label="Email"
                {...register("email", {
                  required: "Email é obrigatório",
                  pattern: {
                    value: /\S+@\S+\.\S+/,
                    message: "Formato de email inválido"
                  }
                })}
              />
              {errors.email && <p role="alert">{errors.email.message}</p>}
              <input
                placeholder="Senha"
                className='form-control custom-input'
                type='password'
                aria-label="Senha"
                {...register("password", { required: true, minLength: 6 })}
              />
              {errors.password && <p role="alert">Senha é obrigatória e deve ter pelo menos 6 caracteres.</p>}
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
