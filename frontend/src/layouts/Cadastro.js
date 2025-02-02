import React from 'react';
import { useForm } from "react-hook-form";
import { useNavigate } from 'react-router-dom';
import "../assets/css/cadastro.css";
import gloves from "../assets/img/gloves.png";
import axios from 'axios';
import { cadastroRoute } from 'API/api';

function Cadastro() {
  const navigate = useNavigate();

  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm();

  const onSubmit = async (req) => {

    const { password, user, email } = req
    try {
      const { data } = await axios.post(cadastroRoute, {
        name: user,
        password: password,
        email: email
      })

      console.log(data)
      if (data.status === false)
        alert(data.message)
      if (data.status === true) {
        navigate("/login");
      }
    } catch (error) {

    }
  };

  console.log(watch("example"));

  return (
    <>
      <div className='left-content'>
        <div className='icon'></div>
        <div className='title-punch'>
          <h1>PunchVision</h1>
        </div>
        <div>
          <img src={gloves} alt='blue glove' className='img-cadastro' />
        </div>
      </div>
      <div className='right-content'>
        <form className='custom-form' onSubmit={handleSubmit(onSubmit)}>
          <div className='title-register'>
            <h1>Crie Sua Conta</h1>
          </div>
          <div>
            <input
              placeholder="Nome Usuário"
              className='form-control custom-input'
              type='text'
              aria-label="Usuário"
              {...register("user", { required: true, minLength: 6 })}
            />
            {errors.user && <p role="alert">Nome de usuário é obrigatório e deve ter pelo menos 6 caracteres.</p>}

            <input
              placeholder="Senha"
              className='form-control custom-input'
              type='password'
              aria-label="Senha"
              {...register("password", { required: true, minLength: 6 })}
            />
            {errors.password && <p role="alert">Senha é obrigatória e deve ter pelo menos 6 caracteres.</p>}

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
          </div>
          <button type="submit" className="btn btn-primary cadastro-btn">Submit</button>
        </form>
      </div>
    </>
  );
}

export default Cadastro;
