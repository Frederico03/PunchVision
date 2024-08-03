import React from 'react';
import { useForm } from "react-hook-form";
import { useNavigate } from 'react-router-dom';
import "../assets/css/cadastro.css";
import blueglove from "../assets/img/blueglove.png";
import redglove from "../assets/img/redglove.png";

function Cadastro() {
  const navigate = useNavigate();

  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm();

  const onSubmit = async (req) => {
    console.log(req);
    const { password, user, email } = req
    const { data } = await axios.post(cadastroRoute, {
      user,
      password,
      email
    })
    if (data.status === false)
      alert(data.message)
    if (data.status === true) {
      localStorage.setItem('punch-vison-user', JSON.stringify(data.token))
      navigate("/");
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
          <img src={blueglove} alt='blue glove' className='img-cadastro' />
          <img src={redglove} alt='red glove' className='img-cadastro' />
        </div>
      </div>
      <div className='content'>
        <form className='form' onSubmit={handleSubmit(onSubmit)}>
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
