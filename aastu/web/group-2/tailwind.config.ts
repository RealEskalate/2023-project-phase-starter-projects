/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './app/**/*.{js,ts,jsx,tsx,mdx}',
    './pages/**/*.{js,ts,jsx,tsx,mdx}',
    './components/**/*.{js,ts,jsx,tsx,mdx}',

    // Or if using `src` directory:
    './src/**/*.{js,ts,jsx,tsx,mdx}',
  ],
  darkMode: 'class',
  theme: {
    extend: {
      colors: {
        dark: {
          background: '#060c19',
          backgroundLight: 'rgb(15 23 42)',
          textColor: {
            50: '#94a3b8',
            100: '#f5f5f5',
          },
          black: 'black',
          white: 'white',
        },

        background: '#F5F5F5',
        backgroundLight: 'white',
        textLight: '',
        black: 'black',
        white: 'white',
        textColor: {
          50: '#878593',
          100: '#7D7D7D',
          200: '#37474F',
          300: '#363636',
        },
        primaryColor: '#264FAD',
        secondaryColor: '#160041',
      },
    },
    fontFamily: {
      primaryFont: ['Poppins', 'sans-serif'],
      secondaryFont: ['Montserrat', 'sans-serif'],
    },
  },
  plugins: [],
};
