import React, { useState } from "react";
import images from "~/assets/image";
import styles from "./Login.module.scss";
import classNames from "classnames/bind";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faLock, faUser } from "@fortawesome/free-solid-svg-icons";
import { login } from "~/api/auth";
import { useAuth } from "~/context/AuthContext";
import { TokenResponse } from "~/api/types/Auth";
import { useNavigate } from "react-router-dom";
const cx = classNames.bind(styles);

const Login: React.FC = () => {
  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [rememberMe, setRememberMe] = useState<boolean>(false);
  const { setTokens } = useAuth();
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const response: TokenResponse = await login(email, password);
      if (response.accessToken.token && response.refreshToken.token) {
        setTokens(response.accessToken.token, response.refreshToken.token);
        navigate("/");
      } else {
        console.error("Login failed: No token received");
      }
    } catch (error) {
      console.error("Login error:", error);
    }
  };
  return (
    <div className={cx("wrapper")}>
      <div className={cx("content")}>
        <div className={cx("image")}>
          <img src={images.login} alt="register" />
        </div>
        <div className={cx("main")}>
          <h1>Sign in</h1>
          <form
            onSubmit={(e) => {
              e.preventDefault();
              handleLogin();
            }}
          >
            <div className={cx("input-group")}>
              <FontAwesomeIcon size="xs" icon={faUser} />
              <input
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                type="text"
                placeholder="Email"
              />
            </div>

            <div className={cx("input-group")}>
              <FontAwesomeIcon size="xs" icon={faLock} />

              <input
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                type="password"
                placeholder="Password"
              />
            </div>

            <div className={cx("remember-me")}>
              <input type="checkbox" />
              <label>Remember me</label>
            </div>
            <button type="submit">Login</button>
          </form>
          <div className={cx("signin-link")}>
            <a href="#">Create an account</a>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Login;
