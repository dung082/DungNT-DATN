/** @type {import('tailwindcss').Config} */
export default {
  content: ["./index.html", "./src/**/**/*.{js,ts,jsx,tsx}"],
  theme: {
    extend: {
      colors: {
        colorthemes: "#0e79e7",
        white : "#fff"
      },
    },
  },
  plugins: [],
};
