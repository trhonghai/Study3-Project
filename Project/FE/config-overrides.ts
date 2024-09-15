import { override, addBabelPlugins } from "customize-cra";
import { Configuration } from "webpack";

const config: Configuration = override(
  ...addBabelPlugins([
    "module-resolver",
    {
      root: ["./src"],
      alias: {
        "~": "./src",
      },
    },
  ])
);

export default config;
