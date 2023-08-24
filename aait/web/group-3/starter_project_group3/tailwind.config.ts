import type { Config } from "tailwindcss";

const config: Config = {
  content: [
    "./pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}",
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    extend: {
      backgroundImage: {
        "gradient-radial": "radial-gradient(var(--tw-gradient-stops))",
        "gradient-conic":
          "conic-gradient(from 180deg at 50% 50%, var(--tw-gradient-stops))",
      },
      colors: {
        background: "#E6E6E6",
        primary: "#264FAD",
        nav_text_color: "#565656",
        blog_list_sub_text_color: "#737373",
        blog_icons_text_color: "#8E8E8E",
        blog_readMore_text_color: "#7367F0",
        blog_owner_name_text_color: "#5E5873",
        blog_pending_icon_text_color: "#FF9F43",
      },
      fontFamily: {
        Montserrat: ["Montserrat", "sans-serif"],
      },
    },
  },
  plugins: [],
};
export default config;
