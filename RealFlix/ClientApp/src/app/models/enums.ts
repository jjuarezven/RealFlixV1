export enum Channels {
  NatGeo = 'National Geographic',
  Warner = 'Warner Channel',
}

export enum Language {
  'English',
  'Spanish',
}

export enum Genre {
  'Drama',
  'Music',
  'Romance',
  'Science-Fiction',
  'Thriller',
  'Action',
  'Crime',
  'Horror',
  'Mystery',
  'Adventure',
}

export enum SearchOptions {
  keywords = 0,
  language,
  genre,
  channel,
  schedule,
  date,
}

type IIteration = (name: string, value: string | number) => void;

export class EnumUtils {
  private static EXPRESSION: RegExp = /^[0-9]+$/g;

  public static iterate<T>(type: T, iteration: IIteration) {
    for (const name in type) {
      if (name.match(this.EXPRESSION)) { continue; }

      iteration(name, <any>type[name]);
    }
  }
}
