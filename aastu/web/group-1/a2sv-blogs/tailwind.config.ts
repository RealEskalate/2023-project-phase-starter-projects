import type { Config } from "tailwindcss";

const config: Config = {
  content: [
    "./src/pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./src/components/**/*.{js,ts,jsx,tsx,mdx}",
    "./src/app/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    extend: {
      fontFamily: {
        poppins: ["Poppins", "sans-serif"],
        montserrat: ["Montserrat", "sans-serif"],
        nunito: ["Nunito", "sans-serif"],
        french: ["IM Fell French Canon", "serif"],
        DmSans: ["DM Sans"],
      },
      colors: {
        primary: "#264FAD",
        secondary: "#5F0A87",
        "text-header": {
          1: "#363636",
          2: "#424242",
        },
        "text-content": "#7d7d7d",
      },
    },
  },
  plugins: [],
};
export default config;
