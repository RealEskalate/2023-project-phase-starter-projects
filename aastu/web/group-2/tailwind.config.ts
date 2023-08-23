/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
    "./pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}",
 
    // Or if using `src` directory:
    "./src/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    // screens: {
    //   sm: "480px",
    //   md: "768px",
    //   lg: "976px",
    //   xl: "1440px",
    // },
    extend: {
      colors: {
        primaryColor: '#264FAD',
        primaryColorLight: '#F2F3F4',
        secondaryColor: '#160041',
        textColor: {
          50: '#878593',
          100: '#7D7D7D',
          200: '#37474F',
          300: '#363636',
        },

      }
    },
    fontFamily: {
      primaryFont: ["Poppins", "sans-serif"],
      secondaryFont: ["Montserrat", "sans-serif"],
    }
  },
  plugins: [],
}

