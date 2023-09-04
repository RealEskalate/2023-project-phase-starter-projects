import type { Config } from "tailwindcss";

const config: Config = {
  content: [
    "./pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}",
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    extend: {
      colors: {
        background: "#FFF",
        primary: "#264FAD",
        bg_blog_upload:'#F2F3F4',
        nav_text_color: "#565656",
        blog_list_sub_text_color: "#737373",
        blog_icons_text_color: "#8E8E8E",
        blog_readMore_text_color: "#7367F0",
        blog_owner_name_text_color: "#5E5873",
        blog_pending_icon_text_color: "#FF9F43",
        login_color: "#3C3C3C",
        light_gray_text_color: "#7D7D7D",
        black_text_color: "#363636",
        lavender: "#F6F6FC",
        dark_chocol: "#4D4A49",
        blue_gray: "#37474F",
        dodger_blue: "#019CFA",
        very_dark_blue: "#01112D"
      },
      fontFamily: {
        Montserrat: ["Montserrat", "sans-serif"],
        Poppins: ["Poppins", "sans-serif"],
        Nunito: ['Nunito', 'sans-serif'],
        Lato: ['Lato', 'sans-serif'],
        Fira_code: ['Fira Code', 'monospace'],
        Inter: ['Inter', 'sans-serif']
      },
      screens: {
        "nav_bar_screen" : "983px"
      }
    },
  },
  plugins: [
    require('tailwindcss-animated'),
  ],
};
export default config;
