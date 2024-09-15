import { useState } from "react";
import images from "~/assets/image";
import styles from "./Register.module.scss";
import classNames from "classnames/bind";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faEnvelope,
  faLock,
  faPhone,
  faUser,
} from "@fortawesome/free-solid-svg-icons";
import React from "react";
import { register } from "~/api/auth";

const cx = classNames.bind(styles);

interface RegisterFormProps {
  // Add any props if needed
}

const Register: React.FC<RegisterFormProps> = () => {
  const [firstName, setFirstName] = useState<string>("");
  const [lastName, setLastName] = useState<string>("");
  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [rePassword, setRePassword] = useState<string>("");
  const [phone, setPhone] = useState<string>("");
  const [termsAccepted, setTermsAccepted] = useState<boolean>(false);

  const handleRegister = async () => {
    try {
      const response = await register({
        firstName,
        lastName,
        email,
        password,
        rePassword,
        phoneNumber: phone,
      });

      console.log(response);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div className={cx("wrapper")}>
      <div className={cx("content")}>
        <div className={cx("image")}>
          <img src={images.register} alt="register" />
        </div>
        <div className={cx("main")}>
          <h1>Sign up</h1>
          <form
            onSubmit={(e) => {
              e.preventDefault();
              handleRegister();
            }}
          >
            <div className={cx("input-group")}>
              <FontAwesomeIcon size="xs" icon={faUser} />
              <input
                type="text"
                placeholder="First Name"
                value={firstName}
                onChange={(e) => setFirstName(e.target.value)}
              />
              <FontAwesomeIcon size="xs" icon={faUser} />
              <input
                type="text"
                placeholder="Last Name"
                value={lastName}
                onChange={(e) => setLastName(e.target.value)}
              />
            </div>
            <div className={cx("input-group")}>
              <FontAwesomeIcon size="xs" icon={faEnvelope} />
              <input
                type="email"
                placeholder="Your Email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              />
            </div>
            <div className={cx("input-group")}>
              <FontAwesomeIcon size="xs" icon={faLock} />
              <input
                type="password"
                placeholder="Password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
            </div>
            <div className={cx("input-group")}>
              <FontAwesomeIcon size="xs" icon={faLock} />
              <input
                type="password"
                placeholder="Repeat your password"
                value={rePassword}
                onChange={(e) => setRePassword(e.target.value)}
              />
            </div>
            <div className={cx("input-group")}>
              <FontAwesomeIcon size="xs" icon={faPhone} />
              <input
                type="text"
                placeholder="Your phone"
                value={phone}
                onChange={(e) => setPhone(e.target.value)}
              />
            </div>
            <div className={cx("checkbox-group")}>
              <input
                type="checkbox"
                id="terms"
                checked={termsAccepted}
                onChange={(e) => setTermsAccepted(e.target.checked)}
              />
              <label htmlFor="terms">
                I agree all statements in <a href="#">Terms of service</a>
              </label>
            </div>
            <button type="submit">Register</button>
          </form>
          <p className={cx("signup-link")}>I am already member</p>
        </div>
      </div>
    </div>
  );
};

export default Register;
