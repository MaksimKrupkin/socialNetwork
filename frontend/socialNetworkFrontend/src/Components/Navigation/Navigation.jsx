import React from 'react';
import styles from './Navigation.module.scss';
import { FaRegNewspaper } from 'react-icons/fa6';
import { TbMessageCircle } from 'react-icons/tb';
import { IoPerson } from 'react-icons/io5';
import { FaUserFriends } from 'react-icons/fa';
import { IoPeopleSharp } from 'react-icons/io5';
import { IoSettingsSharp } from 'react-icons/io5';
import { FaPencil } from 'react-icons/fa6';

const Navigation = () => {
  return (
    <div className={styles.wrapper}>
      <header className={styles.header}>
        <div className={styles.logo}>Brimo</div>
      </header>
      <div className={styles.item}>
        <IoPerson fontSize={20} />
        <span className={styles.text}>Моя страница</span>
      </div>
      <div className={styles.item}>
        <FaRegNewspaper fontSize={20} />
        <span className={styles.text}>Главная</span>
      </div>
      <div className={styles.item}>
        <TbMessageCircle fontSize={20} />
        <span className={styles.text}>Мессенджер</span>
      </div>
      <div className={styles.item}>
        <FaUserFriends fontSize={20} />
        <span className={styles.text}>Подписки</span>
      </div>
      <div className={styles.item}>
        <IoPeopleSharp fontSize={20} />
        <span className={styles.text}>Подписчики</span>
      </div>
      <div className={styles.item}>
        <IoSettingsSharp fontSize={20} />
        <span className={styles.text}>Настройки</span>
      </div>
      <hr className={styles.line} />
      <div className={styles.item}>
        <span className={styles.text}>Понравилось</span>
      </div>
      <div className={styles.create_new}>
        <FaPencil style={{ color: 'black', fontSize: '20px' }} />
        <span className={styles.button_text}>Создать</span>
      </div>
    </div>
  );
};

export default Navigation;
