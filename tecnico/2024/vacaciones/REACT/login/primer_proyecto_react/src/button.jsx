// SocialButton.js
import React from 'react';

function SocialButton({ platform, onClick }) {
  const colors = {
    Google: '#db4437',
    Facebook: '#4267B2',
    Twitter: '#1DA1F2'
  };

  return (
    <button
      onClick={() => onClick(platform)}
      style={{ backgroundColor: colors[platform], color: 'white', padding: '10px 20px', borderRadius: '5px', margin: '5px', display: 'flex', alignItems: 'center', justifyContent: 'center' }}
    >
      <i className={`fab fa-${platform.toLowerCase()}`} style={{ marginRight: '10px' }}></i>
      {platform}
    </button>
  );
}

export default SocialButton;
