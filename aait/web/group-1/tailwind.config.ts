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
        'blue-first': '#264FAD',
        'field-background-color': '#FDFEFF',
        'primary-color': '#264FAD',
        'dark-blue': '#160041',
        'light-gray': '#424242',
        'black-text-color': '#363636',
        'light-text-color': '#7D7D7D',
        'home-card-gray-bg': '#F6F6FC',
        'deep-gray': '#37474F',
        'form-gray-primary': '#434343',
        'form-input-color': '#767676',
        'form-field-bg': '#EFF3F9',
        'add-blog-chip-color': '#414141',
        'add-blog-chip-bg': '#F5F5F5',
        "card-gray":"#C7C7C7",
        "paragraph-color":"#545465",
        "small-blue":"#1E3A8A"
      },
      screens: {
        mobile: "375px",
        tablet: "768px",
        laptop: "1024px",
        desktop: "1440px",
      },
      fontFamily: {
        montserrat: ["Montserrat", "sans-serif"],
        dmSans: ["DM Sans", "sans-serif"],
        poppins: ["Poppins", "sans-serif"],
        lato: ["Lato", "sans-serif"],
        nunito:["Nunito","sans-serif"],
        firaCode:["Fira Code","sans-serif"],
      },
    },
  },
  plugins: [],
};
export default config;
