/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './app/**/*.{js,ts,jsx,tsx,mdx}',
    './pages/**/*.{js,ts,jsx,tsx,mdx}',
    './components/**/*.{js,ts,jsx,tsx,mdx}',

    // Or if using `src` directory:
    './src/**/*.{js,ts,jsx,tsx,mdx}',
  ],
  theme: {
    extend: {
      colors: {
        primaryColor: '#264FAD',
        secondaryColor: '#160041',
        textColor: {
          light: '#F5F5F5',
          lightGray: '#8E8E8E',
          50: '#878593',
          100: '#7D7D7D',
          200: '#37474F',
          300: '#363636',
        },
      },
    },
    fontFamily: {
      primaryFont: ['Poppins', 'sans-serif'],
      secondaryFont: ['Montserrat', 'sans-serif'],
    },
  },
  plugins: [],
};
